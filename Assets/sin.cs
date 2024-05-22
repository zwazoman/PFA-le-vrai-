using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sin : MonoBehaviour
{
    [SerializeField] float phase = 0;
    [SerializeField] float frequency = 2;
    [SerializeField] float amplitude =  .5f;
    [SerializeField] float RotationSpeed = 6;
    [SerializeField] Vector3 Axis = new Vector3(0,1,0);

    [SerializeField] bool isLocal;

    Interactable i;

    void Start()
    {
        phase = Random.value*2*Mathf.PI;
    }

    

    // Update is called once per frame
    void Update()
    {
        
        if (!isLocal)
        {
            transform.position += Axis * amplitude * Mathf.Sin(Time.time * frequency + phase);
        }
        else
        {
            transform.Rotate(Axis*RotationSpeed*Time.deltaTime);
            transform.localPosition += Axis * amplitude * Mathf.Sin(Time.time * frequency + phase);
        }
        
    }
}
