using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovement : MonoBehaviour
{
    Vector3 vel = Vector3.zero;
    RectTransform t;
    [SerializeField] float smoothTime,Amplitude;
    private void Start()
    {
        t=GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        t.anchoredPosition = Vector3.SmoothDamp(t.anchoredPosition, PlayerMain.Instance.InputManager.moveInput * Amplitude, ref vel, smoothTime);
    }
}
