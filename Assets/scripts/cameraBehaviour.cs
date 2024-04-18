using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    GameObject target;
    Vector3 vel;
    Vector3 Offset;
    [SerializeField] float smoothTime;
    void Start()
    {  
        target=PlayerMain.Instance.gameObject;
        Offset = -target.transform.position + transform.position;
        PlayerMain.Instance.InputManager.OnSprintStart += Dezoom;
        PlayerMain.Instance.InputManager.OnSprintEnd += Zoom;
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position+Offset, ref vel, smoothTime);
    }

    private void Zoom()
    {
        //gameObject.GetComponent<Camera>().fieldOfView =
    }

    private void Dezoom()
    {
        //gameObject.GetComponent<Camera>().fieldOfView = 
    }
}
