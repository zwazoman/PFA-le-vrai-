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
        _stock = _maxStock;
        _itemBasePosition = _gameObjectToSell.transform.position;
        _basePhase = Random.value * 100;
    }
    private void Start()
    {
        if(CanRestock) TimeManager.Instance.OnDay += Restock;
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
        Destock();
        GameObject gameObjectToPickup = Instantiate(_gameObjectToSell, transform.position, Quaternion.identity);
        gameObjectToPickup.GetComponent<Item>().InteractWith();
        //Item itemToPickup = gameObjectToPickup.GetComponent<Item>();
        //PlayerMain.Instance.Hands.Pickup(itemToPickup);
    }

    void Destock()
    {
        _stock -= 1;
        if (_stock == 0)
        {
            _itemShopVisual.enabled = false;
        }
    }

    public void Restock()
    {
        _itemShopVisual.enabled = true;
        _stock = _maxStock;
    }
}
