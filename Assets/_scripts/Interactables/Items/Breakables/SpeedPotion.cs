using UnityEngine;

public class SpeedPotion : Item
{
    [SerializeField] float _speedFactor;

    protected override void Interaction()
    {
        base.Interaction();
        print("rammasser potion");
        PlayerMain.Instance.InputManager.OnItem += Drink;
    }

    public override void Drop()
    {
        print("lacher potion");
        PlayerMain.Instance.InputManager.OnItem -= Drink;
    }
    private void Drink()
    {
        //jouer l'animation de con là et faut enlever la bouteille chépa
        print("boire");
        AddSpeed();
        PlayerMain.Instance.Hands.Drop();
        Destroy(gameObject);
    }

    private void AddSpeed()
    {
        PlayerMain.Instance.Stats.MultiplyRunFactor(_speedFactor);
    }

}

