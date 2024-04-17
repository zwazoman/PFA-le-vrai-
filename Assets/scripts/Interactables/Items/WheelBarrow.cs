using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBarrow : Interactable
{
    //[SerializeField] float _distanceToLink;
    public override void InteractWith()
    {
        PlayerMain.Instance.WheelBarrow.Equip();
        /*transform.position = PlayerMain.Instance.gameObject.transform.position + transform.forward * _distanceToLink;
        transform.rotation = PlayerMain.Instance.gameObject.transform.rotation;*/
    }
}
