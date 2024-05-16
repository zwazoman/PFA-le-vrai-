using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField]  Transform door1;
    Quaternion BaseRot1;
    [SerializeField] private Vector3 openRotation1;

    [SerializeField]  Transform door2;
    Quaternion BaseRot2;
    [SerializeField] private Vector3 openRotation2;

    [SerializeField] float openingDuration = 0.3f;
    [SerializeField] GameObject Cadenas;

    Vector3 bs;
    private void Awake()
    {
        BaseRot1 = door1.localRotation;
        BaseRot2 = door2.localRotation;
    }

    public virtual void Open()
    {
        bs = Cadenas.transform.localScale;
        StartCoroutine(Nathan.InterpolateOverTime(0,1,openingDuration,jenpeuplu,Nathan.SmoothStep01,()=> Destroy(Cadenas)));
        Cadenas.GetComponentInChildren<Collider>().enabled = false;
    }

    

    private void jenpeuplu(float alpha)
    {
        door2.localRotation = Quaternion.Slerp(BaseRot2,Quaternion.Euler(openRotation2),alpha);
        door1.localRotation = Quaternion.Slerp(BaseRot1,Quaternion.Euler(openRotation1),alpha);

        
        Cadenas.transform.localScale = Vector3.Lerp(bs,Vector3.zero,alpha);
    }
}
