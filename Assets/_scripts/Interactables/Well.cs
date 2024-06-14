using UnityEngine;

public class Well : Interactable
{
    [SerializeField] AudioClip[] _wellSounds;
    [SerializeField] float _wellSoundsVolume = 1f;

    protected override void Interaction()
    {
        ReplenishWateringCan();
    }

    public void ReplenishWateringCan()
    {
        SFXManager.Instance.PlaySFXClip(_wellSounds, transform.position, _wellSoundsVolume, false, true);
        PlayerMain.Instance.Watering.Replenish();
        RumbleManager.instance.RumblePulse(0.5f, 0.5f, 0.1f);
    }
}
