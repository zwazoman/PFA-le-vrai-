using UnityEngine;

public class DynamicObject : MonoBehaviour
{
    Rigidbody rb;
    SphereCollider col;
    Vector3 TotalForce;

    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] private int MaxCollisionTests = 5;
    [SerializeField] private Vector3 velocity;
    [SerializeField] [Range(0,1)] private float bounciness=0.5f;
    
    public float currentSlopeAngle { get; private set; }
    public Vector3 Velocity => velocity;


    public float GroundFriction;
    public float Airfriction;
    public float Gravity;
    public float MaxSlopeAngle = 30;
    public float GroundCheckDistance = 0.01f;
    public bool isGrounded { get ;private set; }

    public FrameInfo LastFrameInfo { get; private set; } = new();

    [Range(1,5)]
    public int speedMultiplier = 1;
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

    // Start is called before the first frame update
    void Awake()
    {
        initPhysics();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for(int i = 0;i< speedMultiplier; i++)
        {
            UpdatePhysics();
        }   
    }

    public void AddForce(Vector3 Force)
    {
        TotalForce += Force*Time.deltaTime;
    }

    public void AddImpulse(Vector3 Impulse)
    {
        TotalForce += Impulse;
    }

    protected void initPhysics()
    {
        TryGetComponent<SphereCollider>(out col);
        TryGetComponent<Rigidbody>(out rb);
    }

    protected void UpdatePhysics()
    {
        AddForce(Vector3.down * Gravity);

        UpdateLastFrameInfo();
        velocity+=TotalForce;
        TotalForce = Vector3.zero;

        ApplyHorizontalFriction();

        checkForGround();
        CheckForCollision();
        
        //rb.MovePosition(rb.position+Velocity*Time.deltaTime);
        transform.position += velocity * Time.deltaTime;

        
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
        //Vector3 vel = velocity;
        //if(isGrounded) vel.y = Mathf.Max(vel.y, 0);
        if(Physics.SphereCast(transform.position, col.radius, velocity, out hit, velocity.magnitude * Time.deltaTime, collisionLayer))
        {
            print("normal collision !");
            //transform.position = hit.point - Velocity.normalized * col.radius;
            //if(Vector3.Dot(hit.normal, velocity)<0)  
            velocity =Vector3.Lerp(Vector3.ProjectOnPlane(velocity, hit.normal), Vector3.Reflect(velocity, hit.normal), bounciness);


            if (n > 0) print($"{n} collisions this frame" );
            if(n<MaxCollisionTests) CheckForCollision(n + 1); else velocity = Vector3.zero;
        }
        else if (Physics.Raycast(transform.position, velocity, out hit, col.radius, collisionLayer)) //si il a d�j� clipp� � l'int�rieur d'un objet,j'�ssaie de l'en sortir.
        {
            //transform.position = hit.point - Velocity.normalized * col.radius;
            velocity = Vector3.ProjectOnPlane(velocity, hit.normal);

            print("raycastCollision!");
            if (n > 0) print($"{n} collisions this frame");
            //if (n <= MaxCollisionTests) CheckForCollision(n + 1);
        }

    }
    

    private void ApplyHorizontalFriction()
    {
        float y = velocity.y;
        velocity.y = 0;

        velocity += Vector3.ClampMagnitude(-velocity,(isGrounded? GroundFriction : Airfriction)*Time.deltaTime);

        velocity.y = y;
    }

    public void ResetVelocity()
    {
        velocity=Vector3.zero;
        TotalForce = Vector3.zero;
    }
    public Vector3 getFlatVelocity()
    {
        return new Vector3(velocity.x, 0, velocity.z);
    }

}
