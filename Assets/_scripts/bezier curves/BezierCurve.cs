
using System.Collections.Generic;

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
    List<Vector3> pts => linearSampledPoints;

    [Range(0, 1)]
    public float testValue;

#if UNITY_EDITOR
    void Update()
    {
        Debug.DrawRay(Sample(testValue), Vector3.up * 20, Color.red);

        if (points.Count >= 2) 
        Draw();

        testValue = (testValue - 0.1f * Time.deltaTime)%1;

        if (Application.isPlaying)
        {
            GetClosestPoint(PlayerMain.Instance.transform.position);
        }
    }
#endif

    /// <summary>
    /// utilisé pour calculer un point de la courbe entre deux control points. Les points retournés ne sont pas répartis équitablements par rapport à l'alpha rentrée.
    /// </summary>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public Vector3 sampleCurveSegment(int A,int B,float alpha)
    {
        if (points[A] == null || points[B] == null) return Vector3.zero;

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
    /// utilisé pour calculer un ensemble de points équidistants les un aux autres tout le long de la courbe.
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
        if(points[points.Count - 1]!=null) sampledPoints[sampledPoints.Length-1] = points[points.Count-1].transform.position;


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

            if(DistanceToTravelUntilNextSample < CurrentSegmentLength)//si deux traits bleus doivent etre entre deux traits verts, alors ça marche pas mais flemme.
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

    /// <summary>
    /// utilisé pour calculer un point à un endroit précis sur le long de la courbe. La position de sortie est proportionnelle à l'alpha rentrée; c'est linéaire. 
    /// </summary>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public Vector3 Sample(float alpha) 
    {
        alpha *= linearSampledPoints.Count;
        int c = Mathf.FloorToInt(alpha);
        alpha = alpha % 1f;

        return Vector3.Lerp(linearSampledPoints[Mathf.Clamp(c , 0, linearSampledPoints.Count - 1)], linearSampledPoints[Mathf.Clamp( c + 1,0, linearSampledPoints.Count-1)], alpha);
        
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



    private void OnValidate()
    {
        foreach(BezierCurveControlPoint point in points)
        {
            if(point!=null) point.curve = this;
        }

        this.Recalculate();
    }

    private void Awake()
    {
        OnValidate();
    }

    /// <summary>
    /// ça trouve le points le plus proche du joueur (ça dépend dla résolution jcrois)
    /// </summary>
    /// <param name="position"></param>
    /// <param name="resolution"></param>
    /// <returns></returns>
    public int[] FindTwoClosestIndices(Vector3 position, int resolution, int startIndex, int endIndex)
    {
        int iclosest1 = startIndex;
        int iclosest2 = startIndex;
        float distanceToClosest1 = (position - pts[0]).sqrMagnitude;
        int step = (endIndex - startIndex) / resolution;
        for (int i = startIndex; i < endIndex; i += step)
        {
            Debug.DrawRay(linearSampledPoints[i], Vector3.up * 10, Color.green);
            float distance = (position - pts[i]).sqrMagnitude;
            if(distance < distanceToClosest1)
            {
                distanceToClosest1 = distance;
                iclosest1 = i;
                //si c'est cassé tkt
                float leftDistance = (position - pts[iclosest1 - step]).sqrMagnitude;
                float rightDistance = (position - pts[iclosest1 + step]).sqrMagnitude;
                iclosest2 = (leftDistance < rightDistance) ?  iclosest1 - step:  iclosest1 + step;
            }
        }
        Debug.DrawRay(linearSampledPoints[iclosest1], Vector3.up * 10, Color.red);
        Debug.DrawRay(linearSampledPoints[iclosest2], Vector3.up * 10, Color.magenta);

        return new int[2] { iclosest1, iclosest2 };
    }

    public Vector3 GetClosestPoint(Vector3 bahLePoint)
    {
        int[] suu = FindTwoClosestIndices(bahLePoint, 10, 0, pts.Count);
        suu = FindTwoClosestIndices(bahLePoint, 10, Mathf.Min(suu[0], suu[1]), Mathf.Max(suu[0], suu[1]));
        suu = FindTwoClosestIndices(bahLePoint, Mathf.Abs(suu[1] - suu[0]), Mathf.Min(suu[0], suu[1]), Mathf.Max(suu[0], suu[1]) + 15);
        return pts[suu[0]];
    }
}

