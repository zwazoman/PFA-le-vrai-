using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSellingSpot : SellingSpot
{
    [SerializeField] protected GameObject _gameObjectToSell;


    //item floating animation
    Vector3 _itemBasePosition;
    float _basePhase;

    private void Awake()
    {
        _itemBasePosition = _gameObjectToSell.transform.position;
        _basePhase = Random.value * 100;
        _stock = _maxStock;

    }

    public override void SellItem()
    {
        base.SellItem();
        GiveItem();
    }

    private void Update()
    {
        //animation de l'item
        if(TimeManager.Instance.isPaused)
        {
            _gameObjectToSell.transform.position = _itemBasePosition + Vector3.up * Mathf.Sin(Time.time * 2+ _basePhase) * 0.3f;
            _gameObjectToSell.transform.Rotate(Vector3.up, Time.deltaTime * 20,Space.World);
        }
        
    }

    private void GiveItem()
    {
        GameObject gameObjectToPickup = Instantiate(_gameObjectToSell, transform.position, Quaternion.identity);
        gameObjectToPickup.GetComponent<Item>().InteractWith();
        //Item itemToPickup = gameObjectToPickup.GetComponent<Item>();
        //PlayerMain.Instance.Hands.Pickup(itemToPickup);
    }
}
