using UnityEngine;

/// <summary>
/// Pas touche aux lignes commentées Nestor; c'est des features désactivées mais qu'on pourra récupérer plus tard si ça bug
/// </summary>
/// 


public class DynamicObject : MonoBehaviour
{


    Rigidbody rb;
    SphereCollider col;
    Vector3 TotalForce;

    [Header("Collisions")]
    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] private int MaxCollisionTests = 5;
    public float GroundCheckDistance = 0.01f;
    public float MaxSlopeAngle = 30;

    [Header("Physics")]
    [SerializeField] private Vector3 velocity;
    [SerializeField] [Range(0,1)] private float bounciness=0.5f;

    [HideInInspector]
    public float currentSlopeAngle { get; private set; }
    public Vector3 Velocity => velocity;

    public float Gravity;
    public float GroundFriction;
    public float Airfriction;
    
    


    public bool isGrounded{ get ;private set; }

    public FrameInfo LastFrameInfo { get; private set; } = new();

    [Range(1,5)]
    public int speedMultiplier = 1;

    [SerializeField] bool UseCharacterController = false;
    CharacterController CharacterController;
    public struct FrameInfo
    {     
        public FrameInfo(Vector3 Position,Vector3 Velocity,bool isGrounded)
        {
            this.Velocity = Velocity;
            this.Position = Position;
            this.isGrounded = isGrounded;
        }
        public Vector3 Position { get; private set; }
        public Vector3 Velocity { get; private set; }
        public bool isGrounded { get; private set; }
    }

    void UpdateLastFrameInfo()
    {
        LastFrameInfo = new FrameInfo(transform.position, velocity, isGrounded);
    }

    void Awake()
    {
        initPhysics();
    }

    void LateUpdate()
    {
        for(int i = 0;i< speedMultiplier; i++)
        {
            UpdatePhysics();
        }   
    }

    /// <summary>
    /// Addforce est fait pour être appelé chaque frame
    /// </summary>
    /// <param name="Force"></param>
    public void AddForce(Vector3 Force)
    {
        TotalForce += Force*Time.deltaTime;
    }

    /// <summary>
    /// AddImpulse est fait pour être appelé ponctuellement
    /// </summary>
    /// <param name="Impulse"></param>
    public void AddImpulse(Vector3 Impulse)
    {
        TotalForce += Impulse;
    }

    /// <summary>
    /// Doit etre appelé dans Awake sinon ça explose
    /// </summary>
    protected void initPhysics()
    {
        TryGetComponent<CharacterController>(out CharacterController);
        TryGetComponent<SphereCollider>(out col);
        TryGetComponent<Rigidbody>(out rb);
    }


    /// <summary>
    /// Doit etre appelé dans LateUpdate sinon ça explose
    /// </summary>
    protected void UpdatePhysics()
    {
        AddForce(Vector3.down * Gravity);

        UpdateLastFrameInfo();
        velocity+=TotalForce;
        TotalForce = Vector3.zero;

        ApplyHorizontalFriction();

        checkForGround();
        CheckForCollision();

        if (!UseCharacterController)
            transform.position += velocity * Time.deltaTime;
        else CharacterController.SimpleMove(velocity * Time.deltaTime);

    }

    void checkForGround()
    {
        RaycastHit hit;
        
        if (Physics.SphereCast(transform.position, col.radius*0.5f, Vector3.down, out hit,GroundCheckDistance + col.radius * 0.5f /*- Mathf.Min(0, velocity.y * Time.deltaTime)*/, collisionLayer))
        {
            //transform.parent = hit.collider.gameObject.transform;
            currentSlopeAngle = Vector3.Angle(Vector3.up, hit.normal);
            isGrounded = currentSlopeAngle <= MaxSlopeAngle;
        }
        else
        {
            //transform.parent = null;
            isGrounded = false;
        }

        //Debug.Log(Vector3.Angle(Vector3.up,hit.normal));
        //isGrounded = Physics.Raycast(transform.position, Vector3.down,out hit, col.radius + 0.02f - Mathf.Min(0, velocity.y * Time.deltaTime), collisionLayer);
    }

    private void CheckForCollision(int n = 0)
    {
        RaycastHit hit;
        //if(isGrounded) vel.y = Mathf.Max(vel.y, 0);
        if(Physics.SphereCast(transform.position, col.radius, velocity, out hit, velocity.magnitude * Time.deltaTime, collisionLayer))
        {
            //print("normal collision !");

            //transform.position = hit.point - Velocity.normalized * col.radius;
            //if(Vector3.Dot(hit.normal, velocity)<0)  
            velocity =Vector3.Lerp(Vector3.ProjectOnPlane(velocity, hit.normal), Vector3.Reflect(velocity, hit.normal), bounciness);


            //if (n > 0) print($"{n} collisions this frame" );

            if(n<MaxCollisionTests) CheckForCollision(n + 1); else velocity = Vector3.zero;
        }
        else if (Physics.Raycast(transform.position, velocity, out hit, col.radius, collisionLayer)) //si il a déjà clippé à l'intérieur d'un objet,j'éssaie de l'en sortir.
        {
            transform.position = hit.point - Velocity.normalized * (col.radius+0.05f);
            velocity = Vector3.ProjectOnPlane(velocity, hit.normal);

            print("raycastCollision!");
            //if (n > 0) print($"{n} collisions this frame");
        }

    }
    
    private void ApplyHorizontalFriction()
    {
        float y = velocity.y;
        velocity.y = 0;

        velocity += Vector3.ClampMagnitude(-velocity,(isGrounded? GroundFriction : Airfriction)*Time.deltaTime);

        velocity.y = y;
    }

    /// <summary>
    /// remet la velocité à 0
    /// </summary>
    public void ResetVelocity()
    {
        velocity=Vector3.zero;
        TotalForce = Vector3.zero;
    }

    /// <summary>
    /// retourne la velocité avec 0 en Y
    /// </summary>
    /// <returns></returns>
    public Vector3 getFlatVelocity()
    {
        return new Vector3(velocity.x, 0, velocity.z);
    }

    /// <summary>
    /// gère les mouvements du joueur en utilisant la physique des rigidbodies
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="maxSpeed"></param>
    /// <param name="acceleration"></param>
    public void Move(Vector3 direction, float maxSpeed, float acceleration)
    {
        float currentSpeed = Vector3.Dot(direction, getFlatVelocity());//*/getFlatVelocity().magnitude;
        float AddSpeed = Mathf.Clamp(maxSpeed - currentSpeed, 0, acceleration * Time.deltaTime);
        AddImpulse(AddSpeed * direction);
    }
}
