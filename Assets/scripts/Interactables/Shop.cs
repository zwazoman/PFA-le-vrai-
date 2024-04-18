using TMPro;
using UnityEngine;
/// <summary>
/// Ce script gere la description le nom et le prix d'un item du shop
/// </summary>
public class Shop : Interactable
{
    [SerializeField] GameObject _panelItem;
    [SerializeField] ShopItem _soItem;
    [SerializeField] TMP_Text _description;
    [SerializeField] TMP_Text _prices;
    [SerializeField] TMP_Text _name;
    protected override void Interaction()
    {
        _panelItem.SetActive(!false);
        _description.text = _soItem.Description;
        _prices.text = _soItem.Price.ToString();
        _name.text = _soItem.Name;
    }
}
