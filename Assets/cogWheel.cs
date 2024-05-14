using UnityEngine;

[ExecuteAlways]
public class cogWheel : MonoBehaviour
{
    [SerializeField] cogWheel otherWheel;
    [SerializeField] float Ratio = 1;
    [SerializeField] Vector3 Axis = new Vector3(0, 0, 1);

    Vector3 baseRotation;
    float offset = 0;

    public float ptn;
    private void OnValidate()
    {
        baseRotation = transform.localEulerAngles;
        if(otherWheel != null)
        offset = Vector3.Dot(transform.localEulerAngles, otherWheel.Axis.normalized);
    }

    private void Awake()
    {
        OnValidate();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.hasChanged)
        {
            ptn = Vector3.Dot(Axis, transform.localEulerAngles)%360;
            if (otherWheel!=null) otherWheel.transform.localEulerAngles = otherWheel.baseRotation + otherWheel.Axis * ( Mathf.Abs( Vector3.Dot(Axis, transform.localEulerAngles))%360f) * (-Ratio);
            transform.hasChanged = false;
        }
    }
}
