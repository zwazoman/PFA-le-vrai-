using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BezierCurve : MonoBehaviour
{
    public int SegmentpointCount = 20;
    public List<BezierCurveControlPoint> points = new List<BezierCurveControlPoint>();
    // Start is called before the first frame update
    public Vector3 sampleCurveSegment(int A,int B,float alpha)
    {
        Vector3 V1 = Vector3.Lerp( points[A].transform.position, points[A].rightTangent.transform.position,alpha);
        Vector3 V2 = Vector3.Lerp(points[A].rightTangent.transform.position, points[B].leftTangent.transform.position, alpha);
        Vector3 V3 = Vector3.Lerp(points[B].leftTangent.transform.position, points[B].transform.position, alpha);

        Vector3 W1 = Vector3.Lerp(V1,V2, alpha);
        Vector3 W2 = Vector3.Lerp(V2, V3, alpha);

        return Vector3.Lerp(W1, W2, alpha);

    }

    void drawSegment(int A,int B)
    {
        Vector3[] sampledPoints = new Vector3[SegmentpointCount+1];
        for (int i = 0; i <= SegmentpointCount; i++)
        {
            sampledPoints[i] = sampleCurveSegment(A, B, (float)i / (float)SegmentpointCount);
            Debug.Log((float)i / (float)SegmentpointCount);
        }
        for (int j = 0; j < SegmentpointCount ; j++)
        {
            Debug.DrawLine(sampledPoints[j], sampledPoints[j + 1], Color.red);
        }
    }

    void drawCurve()
    {
        for (int j = 0; j < points.Count - 1; j++)
        {
            drawSegment(j, j + 1);
        }
    }

    float estimateLength()
    {
        //http://lib.ysu.am/disciplines_bk/cbd159e4a555bc53e8dfa0b64145fa51.pdf
        //essayer de dessiner le polygone subdivisé pour voir

        //si c'est trop chiant de subdiviser la courbe, juste bruteforce en samplant plein de points et en additionnant les distances qui les séparent
        return -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(points.Count>=2)
        drawCurve();
    }
}
