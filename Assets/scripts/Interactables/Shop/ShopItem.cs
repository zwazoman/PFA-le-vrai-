using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Shop", order = 1)] 

public class ShopItem : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Sprite;
    public int Price;
}
