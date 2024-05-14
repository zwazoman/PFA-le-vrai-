using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public DynamicObject target;
    Vector3 vel;
    Vector3 Offset;
    [Header("Movement")]
    [SerializeField] float smoothTime;
    [SerializeField] float PlayerAnticipation = 0;

    [Header("FOV")]
    [SerializeField] AnimationCurve FOVscaleOverSpeed;
    [SerializeField] float FOVchangeSpeed=1;
    float BaseFOV;

    public static CameraBehaviour Instance { get; private set; }

    public Camera cam { get; private set; }

    void Start()
    {
        transform.parent = null;
        Instance = this;//le singleton wish

        cam = GetComponentInChildren<Camera>();
        target =PlayerMain.Instance.Movement;


        Offset = -target.transform.position + transform.position; // naze un peu

        BaseFOV = cam.fieldOfView;
    }

    void Update()
    {
        
        //FOV
        cam.fieldOfView = Nathan.DampFloat(cam.fieldOfView, BaseFOV * FOVscaleOverSpeed.Evaluate(target.getFlatVelocity().magnitude),FOVchangeSpeed);

        //mouvement
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position+Offset + target.getFlatVelocity()*PlayerAnticipation, ref vel, smoothTime);

    }

    public void TeleportToTargetPosition()
    {
        transform.position =  target.transform.position + Offset + target.getFlatVelocity() * PlayerAnticipation;
    }


}
