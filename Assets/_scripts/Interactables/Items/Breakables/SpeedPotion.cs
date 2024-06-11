using UnityEngine;

public class SpeedPotion : Item
{
    [SerializeField] float _speedFactor;

    protected override void Interaction()
    {
        base.Interaction();
        PlayerMain.Instance.InputManager.OnItem += StartDrink;
        PlayerMain.Instance.AnimationEventReceiver.OnStopDrinkPotion.AddListener(StopDrink);
    }

    public override void OnDrop()
    {
        //delink l'event pour boire quand la potion est lachée
        PlayerMain.Instance.InputManager.OnItem -= StartDrink;
        PlayerMain.Instance.AnimationEventReceiver.OnStopDrinkPotion.RemoveListener(StopDrink);
    }
    private void StartDrink()
    {
        PlayerMain.Instance.InputManager.enabled = false;
        PlayerMain.Instance.Visuals.StartDrinkAnimation();
    }

    private void StopDrink()
    {
        AddSpeed();
        PlayerMain.Instance.Hands.Drop();
        PlayerMain.Instance.InputManager.enabled = true;
        Destroy(gameObject);
    }

    private void AddSpeed()
    {
        PlayerMain.Instance.Stats.MultiplyRunFactor(_speedFactor);
    }

}

