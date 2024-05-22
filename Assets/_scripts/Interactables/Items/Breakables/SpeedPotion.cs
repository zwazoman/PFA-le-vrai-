using UnityEngine;

public class SpeedPotion : Breakable
{
    [SerializeField] float _speedFactor;

    private void Awake()
    {
        Maxhp = 1;    
    }

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

