using UnityEngine;

[ExecuteAlways]
public class cogWheel : MonoBehaviour
{
    [SerializeField] cogWheel otherWheel;
    [SerializeField] float Ratio = 1;
    [SerializeField] Vector3 Axis = new Vector3(0, 0, 1);

    public float angle;
    public float angleOffset;
    public Vector3 BaseAngle;


    private void Awake()
    {
        OnValidate();
    }

    // Update is called once per frame
    void OnValidate()
    {
        transform.localEulerAngles = Axis * angle + BaseAngle;
        if (otherWheel != null) otherWheel.UpdateAngle(angle, Ratio);
        transform.hasChanged = false;
        
    }

    public void UpdateAngle(float _oldAngle,float _ratio)
    {
        angle = _oldAngle * -_ratio;
        transform.localEulerAngles = Axis * (angle + angleOffset) + BaseAngle;
        if(otherWheel!=null)otherWheel.UpdateAngle(angle, Ratio);
    }
}
