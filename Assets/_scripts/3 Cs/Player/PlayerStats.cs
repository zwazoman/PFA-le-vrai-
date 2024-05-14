using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [field : HideInInspector]
    public int Seeds { get; set; }
    [field: SerializeField] 
    public int Money {  get; private set ; }
    [field : SerializeField]
    public int InitialSeeds { get; set; }

    [field: SerializeField]
    public float WalkSpeed { get; set; }

    [field: SerializeField]
    public float RunSpeed {  get; set; }

    private void Start()
    {
        Seeds = InitialSeeds;
    }

    public void AddMoney(int toADD)
    {
        Money += toADD;
    }

    public void AddSeeds(int seedAmount)
    {
        InitialSeeds += seedAmount;
        Seeds = InitialSeeds;
    }

    public void TemporarlyAddSeeds(int seedAmount)
    {
        Seeds += seedAmount;
    }
}
