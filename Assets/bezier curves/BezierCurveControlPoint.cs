using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BezierCurveControlPoint : MonoBehaviour
{

    public GameObject leftTangent;
    public GameObject rightTangent;

    // Update is called once per frame
    void Update()
    {
        if (leftTangent != null && leftTangent.transform.hasChanged)
        {
            rightTangent.transform.localPosition = -leftTangent.transform.localPosition;
            leftTangent.transform.hasChanged = false;
        }
        else if (rightTangent != null && rightTangent.transform.hasChanged)
        {
            leftTangent.transform.localPosition = -rightTangent.transform.localPosition;
            rightTangent.transform.hasChanged = false;
        }

        Debug.DrawLine(transform.position, leftTangent.transform.position, Color.cyan);
        Debug.DrawLine(transform.position, rightTangent.transform.position, Color.cyan);

    }
}
