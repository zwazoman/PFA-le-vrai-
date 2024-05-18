using System.Threading.Tasks;
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
    float fovWithoutOffset;

    public static CameraBehaviour Instance { get; private set; }

    public float FOVOffset;
    public float FOVOffsetSpeed;
    public float lambda = 10;

    public Camera cam { get; private set; }

    public void zoomEffect(float intensity)
    {
        /*FOVOffset-=intensity;
        await Task.Delay((int)(delay * 100));
        FOVOffset += intensity;*/

        FOVOffsetSpeed = Mathf.Min(FOVOffsetSpeed,-lambda) - intensity;
    }

    void Start()
    {
        transform.parent = null;
        Instance = this;//le singleton wish

        cam = GetComponentInChildren<Camera>();
        target =PlayerMain.Instance.Movement;


        Offset = -target.transform.position + transform.position; // naze un peu

        BaseFOV = cam.fieldOfView;
        fovWithoutOffset = BaseFOV;
    }

    void Update()
    {
        FOVOffset += FOVOffsetSpeed * Time.deltaTime;
        FOVOffsetSpeed = Mathf.Sign(FOVOffsetSpeed) * (Mathf.Abs(FOVOffsetSpeed) - Mathf.Min(Mathf.Abs(FOVOffsetSpeed), lambda * Time.deltaTime));
        FOVOffset =  Mathf.Sign(FOVOffset) * (Mathf.Abs(FOVOffset) - Mathf.Min(Mathf.Abs( FOVOffset), lambda * Time.deltaTime));

        //FOV
        fovWithoutOffset = Nathan.DampFloat(fovWithoutOffset, BaseFOV * FOVscaleOverSpeed.Evaluate(target.getFlatVelocity().magnitude), FOVchangeSpeed);
        cam.fieldOfView = fovWithoutOffset + FOVOffset;

        //mouvement
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position+Offset + target.getFlatVelocity()*PlayerAnticipation, ref vel, smoothTime);

    }

    public void TeleportToTargetPosition()
    {
        transform.position =  target.transform.position + Offset + target.getFlatVelocity() * PlayerAnticipation;
    }


}
