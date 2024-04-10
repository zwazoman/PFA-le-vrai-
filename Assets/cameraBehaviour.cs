using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{
    GameObject target;
    Vector3 vel;
    Vector3 Offset;
    [SerializeField] float smoothTime;
    // Start is called before the first frame update
    void Start()
    {
        target=FindObjectOfType<PlayerMain>().gameObject; //t'inquiete
        Offset = -target.transform.position + transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position+Offset, ref vel, smoothTime);
    }
}
