using UnityEngine;

[ExecuteAlways]
public class RotateOverTime : MonoBehaviour
{
    public Vector3 LocalAxis;
    public float Speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(LocalAxis, Speed*Time.deltaTime);
    }
}
