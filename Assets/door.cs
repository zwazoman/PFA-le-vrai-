using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    Transform door1;
    Quaternion BaseRot1;
    [SerializeField] private Vector3 openRotation1;

    Transform door2;
    Quaternion BaseRot2;
    [SerializeField] private Vector3 openRotation2;

    [SerializeField] float openingDuration = 0.3f;
    [SerializeField] BoxCollider mainCollider;


    private void Awake()
    {
        BaseRot1 = door1.localRotation;
        BaseRot2 = door2.localRotation;
    }

    public void Open()
    {
        StartCoroutine(Nathan.InterpolateOverTime(0,1,openingDuration,jenpeuplu,Nathan.SmoothStep,()=>mainCollider.enabled = false));

    }

    void jenpeuplu(float alpha)
    {
        door2.localRotation = Quaternion.Slerp(BaseRot2,Quaternion.Euler(openRotation1),alpha);
        door1.localRotation = Quaternion.Slerp(BaseRot1,Quaternion.Euler(openRotation1),alpha);

    }
}
