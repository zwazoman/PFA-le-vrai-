using UnityEngine;

public class Sign : Interactable
{
    bool isActivated = false;

    [SerializeField] string Dialogue;
    protected override void Interaction()
    {
        if(!isActivated)
        {
            Ilesttroptotpourcoderptn();
        }
    }

    async void Ilesttroptotpourcoderptn()
    {
        isActivated = true;
        await UiManager.Instance.PopupSimpleString(Dialogue);
        isActivated = false;
    }
}
