using UnityEngine;

public class WheelBarrowVisual : MonoBehaviour
{
    public GameObject Barrow;
    public float wheelRadius;
    public float maxSlopeAngle = 35f;
    public float kekchos;
    public float truk;

    public float angleOffet = 0;
    public Vector3 localForward;
    [SerializeField] LayerMask layerMask;

    public float angle;
    private void Update()
    {
        if (transform.parent == null) return;
        RaycastHit hit;
        Transform p = transform.parent;

        Debug.DrawRay(/*transform.position + transform.forward * truk*/ p.position - p.forward * truk + Vector3.up * kekchos, Vector3.down * kekchos * 2, Color.yellow);
        if(Physics.Raycast(/*transform.position + transform.forward * truk*/p.position - p.forward * truk + Vector3.up * kekchos, Vector3.down,out hit, kekchos * 2, layerMask))
        {
            localForward = (hit.point - Barrow.transform.position) + Vector3.up * wheelRadius;
            Debug.DrawRay(/*transform.position + transform.forward * truk*/ Barrow.transform.position, localForward, Color.red);

            localForward = p.transform.InverseTransformVector(localForward);
            //Vector3 a = Barrow.transform.localEulerAngles;
            angle = - Mathf.Atan2(localForward.y, localForward.z)* Mathf.Rad2Deg;
            angle = angle > 0 ? angle : angle + 360f;
            //print(angle);

            if (angle > 180f+maxSlopeAngle || angle < 180f-maxSlopeAngle) return;
            angle += angleOffet;
            angle = angle % 360;
            //angle = Mathf.Clamp(angle, minAngle, maxAngle);
            transform.localRotation = Quaternion.Euler( Vector3.right * angle);
            //Barrow.transform.localEulerAngles = new Vector3(/*Mathf.Clamp( a.x,minAngle,maxAngle)*/Mathf.Rad2Deg * Mathf.Atan2(localForward.y, localForward.z)+ angleOffet, 0, 0);
        }
    }
}
