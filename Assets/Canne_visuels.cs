using UnityEngine;

[ExecuteAlways]
public class Canne_visuels : MonoBehaviour
{
    Vector3 bout;

    [Header("References")]
    [SerializeField] GameObject bouchon;
    [SerializeField] Material mat;
    [SerializeField] LineRenderer line;

    [Header("parametres")]
    [SerializeField] float bend;
    [SerializeField] float lineHang;
    [SerializeField] float hauteurBout;
    public Vector3 angleAxis;


    // Update is called once per frame
    void Update()
    {
        BendRod();
        UpdateString();
    }

    void BendRod()
    {
        mat.SetFloat("_bend", bend);
        bout = Matrix4x4.Rotate(Quaternion.Euler(angleAxis * bend * Mathf.Deg2Rad * 2 * Mathf.PI)) * Vector3.forward * hauteurBout;
        bout = transform.TransformPoint(bout);
        Debug.DrawRay(bout, Vector3.up);
    }

    void UpdateString()
    {

        for (int i = 0;i<line.positionCount;i++)
        {
            line.SetPosition(i, LerpParabola(bout,bouchon.transform.position,(float)i / (float) (line.positionCount-1),lineHang));
        }

    }

    Vector3 LerpParabola(Vector3 a,Vector3 b, float alpha,float hanging = 1)
    {
        float x = (2 * alpha - 1f);
        return Vector3.Lerp(a,b,alpha) - Vector3.up * (x * x -1)* hanging ;
    }

}
