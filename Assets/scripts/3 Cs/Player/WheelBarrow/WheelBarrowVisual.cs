using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBarrowVisual : MonoBehaviour
{
    public GameObject Barrow;
    public GameObject Wheel;
    public float wheelRadius;
    public float maxAngle;
    public float kekchos;
    public float truk;
    [SerializeField] LayerMask layerMask;

    private void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(/*transform.position + transform.forward * truk*/ Wheel.transform.position + Vector3.up * kekchos, Vector3.down * kekchos * 2, Color.yellow);
        if(Physics.Raycast(/*transform.position + transform.forward * truk*/Wheel.transform.position + Vector3.up * kekchos, Vector3.down,out hit, kekchos * 2, layerMask))
        {
           Barrow.transform.forward = (-hit.point + Barrow.transform.position) - Vector3.up * wheelRadius;
        }
    }
}
