using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBarrow : Interactable
{
    [SerializeField] float _distanceToLink;
    [SerializeField] float _hightToLink;
    public override void InteractWith()
    {
        PlayerMain.Instance.WheelBarrow.Equip();
        PlayerMain.Instance.WheelBarrow.WB = this;
        transform.parent = PlayerMain.Instance.transform;
        transform.position = PlayerMain.Instance.transform.position + PlayerMain.Instance.transform.forward * _distanceToLink + Vector3.up * _hightToLink;
        transform.rotation = Quaternion.Euler(PlayerMain.Instance.transform.eulerAngles + Vector3.right * 180 + Vector3.forward * 180);
    }

    public void UnEquip()
    {
        transform.parent = null;
    }
}
