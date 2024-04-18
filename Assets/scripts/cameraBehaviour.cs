using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    DynamicObject target;
    Vector3 vel;
    Vector3 Offset;
    [SerializeField] float smoothTime;
    [SerializeField] float PlayerAnticipation = 0;
    void Start()
    {  
        target=PlayerMain.Instance.Movement;
        Offset = -target.transform.position + transform.position;
        PlayerMain.Instance.InputManager.OnSprintStart += Dezoom;
        PlayerMain.Instance.InputManager.OnSprintEnd += Zoom;
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position+Offset + target.Velocity*PlayerAnticipation, ref vel, smoothTime);
    }

    private void Zoom()
    {

    }

    private void Dezoom()
    {

    }
}
