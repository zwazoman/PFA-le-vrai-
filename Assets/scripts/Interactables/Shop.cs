using TMPro;
using UnityEngine;

public class Shop : Interactable
{
    [SerializeField] GameObject _panelItem;
    [SerializeField] ShopItem _soItem;
    [SerializeField] TMP_Text _description;
    [SerializeField] TMP_Text _prices;
    [SerializeField] TMP_Text _name;
    public override void InteractWith()
    {
        _panelItem.SetActive(!false);
        _description.text = _soItem.Description;
        _prices.text = _soItem.Price.ToString();
        _name.text = _soItem.Name;
    }
}
