using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class cogWheel : MonoBehaviour
{
    [SerializeField] cogWheel otherWheel;
    [SerializeField] float Ratio = 1;
    [SerializeField] Vector3 Axis = new Vector3(0, 0, 1);

    Vector3 baseRotation;
    float offset = 0;

    private void OnValidate()
    {
        baseRotation = transform.localEulerAngles;
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
            if(otherWheel!=null) otherWheel.transform.localEulerAngles = otherWheel.baseRotation + otherWheel.Axis *  Vector3.Dot(Axis, transform.localEulerAngles) * (-Ratio);
            transform.hasChanged = false;
        }
    }
}
