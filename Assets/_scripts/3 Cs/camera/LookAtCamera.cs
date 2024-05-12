using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform cam;
    private void Start()
    {
        if(cam == null) cam=Camera.main.transform;
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
