using UnityEngine;
using TMPro;

public class GameplayPanel : MonoBehaviour
{
    public TMP_Text TextMoney;


    public void Start()
    {
        TextMoney.text = PlayerMain.Instance.Stats.Money.ToString();
    }
}

