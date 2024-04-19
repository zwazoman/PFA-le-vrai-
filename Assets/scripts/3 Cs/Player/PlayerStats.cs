using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [field: SerializeField] public int Money
    {  get; private set ; }

    public void AddMoney(int toADD)
    {
        Money += toADD;
    }
}
