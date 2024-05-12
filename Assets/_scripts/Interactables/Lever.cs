using UnityEngine;

public class Lever : Interactable
{
    [SerializeField] MillStorage _millCoin;
    [SerializeField] PlayerStats _playerCoin;
    protected override void Interaction()
    {
        _playerCoin.AddMoney( _millCoin.MillMoney);
        _millCoin.MillMoney = 0;
    }
}
