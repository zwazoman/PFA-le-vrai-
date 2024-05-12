using UnityEngine;

public class BetterWater : Interactable
{
    [SerializeField] float _waterAddition;
    protected override void Interaction()
    {
        PlayerMain.Instance.Can.AddWaterToGive(_waterAddition);
        //a refaire dans la boite de dialogue
    }
}
