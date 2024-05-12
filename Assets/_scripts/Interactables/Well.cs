public class Well : Interactable
{
    protected override void Interaction()
    {
        PlayerMain.Instance.Watering.Replenish();
    }
}
