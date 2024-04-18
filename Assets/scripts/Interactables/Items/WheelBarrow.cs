using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBarrow : Interactable
{
    //[SerializeField] float _distanceToLink;
    protected override void Interaction()
    {
        PlayerMain.Instance.WheelBarrow.Equip();
        /*transform.position = PlayerMain.Instance.gameObject.transform.position + transform.forward * _distanceToLink;
        transform.rotation = PlayerMain.Instance.gameObject.transform.rotation;*/
    }
}
