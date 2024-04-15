using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    [SerializeField] MillStorage _millCoin;
    [SerializeField] PlayerStats _playerCoin;
    public override void InteractWith()
    {
        _playerCoin.Money += _millCoin.MillMoney;
        _millCoin.MillMoney = 0;
    }
}
