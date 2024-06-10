using System.Numerics;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [field : SerializeField]
    public int Seeds { get; set; }
    [field: SerializeField] 
    public int Money {  get; private set ; }

    [field: SerializeField]
    public float WalkSpeed { get; set; }

    [field: SerializeField]
    public float RunFactor {  get; set; }

    bool _drankPotion;

    private int _hour = 0;

    private void Start()
    {
        TimeManager.Instance.OnHour += ResetRunFactor;
    }

    public void AddMoney(int toAdd)
    {
        print("Houla");
        UiManager.Instance.Gameplay_Panel.UpdateDisplay(Money, Money + toAdd);
        QuestManager.Instance.TryProgressQuest("BuySoul", toAdd);
        Money += toAdd;
    }

    public void AddSeeds(int seedAmount)
    {
        Seeds += seedAmount;
    }

    public void MultiplyRunFactor(float factor)
    {
        PlayerMain.Instance.Movement._playerRunFactor *= factor;
        _drankPotion = true;
    }

    private void ResetRunFactor()
    {
        if (_drankPotion)
        {
            _hour++;
            if (_hour == 24)
            {
                PlayerMain.Instance.Movement._playerRunFactor = RunFactor;
                _hour = 0;
                _drankPotion = false;
            }
        }
    }
}
