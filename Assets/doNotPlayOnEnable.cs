using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class doNotPlayOnEnable : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        GetComponent<VisualEffect>().Stop() ;
    }

}
