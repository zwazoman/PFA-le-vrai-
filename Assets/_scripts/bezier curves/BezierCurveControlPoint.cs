using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BezierCurveControlPoint : MonoBehaviour
{

    public GameObject leftTangent;
    public GameObject rightTangent;

    public BezierCurve curve;

    // Update is called once per frame
    void Update()
    {
        if (leftTangent != null && leftTangent.transform.hasChanged)
        {
            Vector3 offset = leftTangent.transform.position - transform.position;
            rightTangent.transform.position = transform.position-offset;
            leftTangent.transform.hasChanged = false;
            curve.Recalculate();
        }
        else if (rightTangent != null && rightTangent.transform.hasChanged)
        {
            Vector3 offset = rightTangent.transform.position - transform.position;
            leftTangent.transform.position = transform.position - offset;
            rightTangent.transform.hasChanged = false;
            curve.Recalculate();

        }

        Debug.DrawLine(transform.position, leftTangent.transform.position, Color.cyan);
        Debug.DrawLine(transform.position, rightTangent.transform.position, Color.cyan);
        if (this.transform.hasChanged)
        {
            curve.Recalculate();

            transform.hasChanged = false;
        }
    }
}
