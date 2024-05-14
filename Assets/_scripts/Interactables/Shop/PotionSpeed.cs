using UnityEngine;

public class PotionSpeed : Breakable
{
    [SerializeField] float _speedFactor;
    protected override void Break()
    {
        AddSpeed();
        base.Break();
    }

    private void AddSpeed()
    {
        PlayerMain.Instance.Stats.MultiplyRunFactor(_speedFactor);
    }

}

