using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : Interactable
{
    public override void InteractWith()
    {
        UiManager.Instance.PopupSimpleString("je suis un panneau");
    }
}
