using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteAlways]
public class BezierCurve : MonoBehaviour
{
    public int SegmentpointCount = 50;
    public List<BezierCurveControlPoint> points = new List<BezierCurveControlPoint>();

    
    public int initialSampleRatePerSegment = 20;
    // Start is called before the first frame update

    public bool test;

    [Min(.5f)]
    public float SegmentTargetLength = 5;

    List<Vector3> linearSampledPoints = new();
    public Vector3 sampleCurveSegment(int A,int B,float alpha)
    {
        Vector3 V1 = Vector3.Lerp( points[A].transform.position, points[A].rightTangent.transform.position,alpha);
        Vector3 V2 = Vector3.Lerp(points[A].rightTangent.transform.position, points[B].leftTangent.transform.position, alpha);
        Vector3 V3 = Vector3.Lerp(points[B].leftTangent.transform.position, points[B].transform.position, alpha);

        Vector3 W1 = Vector3.Lerp(V1,V2, alpha);
        Vector3 W2 = Vector3.Lerp(V2, V3, alpha);

        //Debug.DrawRay(points[A].transform.position, Vector3.up,Color.magenta);
        //Debug.DrawRay(points[B].transform.position, Vector3.up,Color.magenta);
        //Debug.DrawRay(Vector3.Lerp(W1, W2, alpha), Vector3.up, Color.green);
        return Vector3.Lerp(W1, W2, alpha);

    }

    /// <summary>
    /// https://stackoverflow.com/questions/17099776/trying-to-find-length-of-a-bezier-curve-with-4-points
    /// </summary>
    public void Recalculate() 
    {

        //sample points non linearly.
        Vector3[] sampledPoints = new Vector3[(points.Count-1)* initialSampleRatePerSegment + 1];
        for (int i = 0; i < points.Count-1; i++)
        {
            for(int j = 0;j< initialSampleRatePerSegment; j++)

            sampledPoints[i* initialSampleRatePerSegment + j] = sampleCurveSegment(i, i+1,((float)j)/(float)initialSampleRatePerSegment);
            Debug.DrawRay(sampledPoints[i], Vector3.down * 2, Color.blue);
        }
        sampledPoints[sampledPoints.Length-1] = points[points.Count-1].transform.position;


        //estimate curve length;
        List<float> segmentLength = new List<float>();
        float totalLength = 0;
        for (int i = 0; i < points.Count - 1; i++)
        {
            segmentLength.Add(0);
            for (int j = 0; j < initialSampleRatePerSegment; j++)
            {
                segmentLength[i] += Vector3.Distance(sampledPoints[i * initialSampleRatePerSegment + j], sampledPoints[i * initialSampleRatePerSegment + j + 1]);
                Debug.DrawLine(sampledPoints[i * initialSampleRatePerSegment + j]-Vector3.up, sampledPoints[i * initialSampleRatePerSegment + j + 1]-Vector3.up, Color.magenta);

            }
            totalLength += segmentLength[i];
        }

        //linearly resample the curve

        linearSampledPoints.Clear();

        //float targetLength = totalLength / 200f;
        float traveledDistance = 0;
        float DistanceToTravelUntilNextSample = SegmentTargetLength;
        for(int i = 0; i < sampledPoints.Length - 1;i++)
        {
            float CurrentSegmentLength = Vector3.Distance(sampledPoints[i], sampledPoints[i + 1]);

            if(DistanceToTravelUntilNextSample < CurrentSegmentLength)//si deux traits bleus doivent etre entre deux traits verts, alors �a marche pas mais flemme.
            {
                float alpha = 1f - (CurrentSegmentLength - DistanceToTravelUntilNextSample) / CurrentSegmentLength;
                Debug.DrawRay(Vector3.Lerp(sampledPoints[i], sampledPoints[i + 1], alpha), Vector3.up * 5, Color.cyan);
                linearSampledPoints.Add(Vector3.Lerp(sampledPoints[i], sampledPoints[i + 1], alpha));
                DistanceToTravelUntilNextSample = SegmentTargetLength - (CurrentSegmentLength - DistanceToTravelUntilNextSample);
                
            }else
            {
                DistanceToTravelUntilNextSample -= CurrentSegmentLength;
                traveledDistance += CurrentSegmentLength;
            }

        }
    }


    void Draw()
    {
        /*for (int j = 0; j < points.Count - 1; j++)
        {
            drawSegment(j, j + 1);
        }*/
        for (int j = 0; j < linearSampledPoints.Count - 1; j++)
        {
            Debug.DrawRay(linearSampledPoints[j], Vector3.up, Color.green);
            Debug.DrawLine(linearSampledPoints[j], linearSampledPoints[j + 1], Color.red);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Count >= 2) 
        Draw();
    }

    private void OnValidate()
    {
        foreach(BezierCurveControlPoint point in points)
        {
            point.curve = this;
        }

        this.Recalculate();
    }

    private void Awake()
    {
        OnValidate();
    }
}
