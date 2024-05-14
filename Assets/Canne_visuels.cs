using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canne_visuels : MonoBehaviour
{
    Vector3 bout;

    [SerializeField] float bend;
    [Header("References")]
    [SerializeField] GameObject bouchon;
    [SerializeField] Material mat;

    [SerializeField] float hauteurBout;
    public Vector3 angleAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        mat.SetFloat("_bend", bend);

        bout = Matrix4x4.Rotate(Quaternion.Euler(angleAxis * bend * Mathf.Deg2Rad * 2*Mathf.PI) ) * Vector3.forward * hauteurBout;
        bout = transform.TransformPoint(bout);
        Debug.DrawRay(bout,Vector3.up);
    }
}
