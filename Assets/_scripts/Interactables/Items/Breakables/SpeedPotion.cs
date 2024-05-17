using UnityEngine;

public class SpeedPotion : Breakable
{
    [SerializeField] float _speedFactor;
    protected override void Break()
    {
        //jouer _effectSound
        AddSpeed();
        base.Break();
    }

    private void AddSpeed()
    {
        PlayerMain.Instance.Stats.MultiplyRunFactor(_speedFactor);
    }

}

