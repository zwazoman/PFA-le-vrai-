using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : Interactable
{
    bool isActivated = false;
    public override void InteractWith()
    {
        if(!isActivated)
        {
            Ilesttroptotpourcoderptn();
        }
    }

    async void Ilesttroptotpourcoderptn()
    {
        isActivated = true;
        await UiManager.Instance.PopupSimpleString("je suis un panneau");
        isActivated = false;
    }
}
