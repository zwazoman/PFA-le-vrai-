using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TMP_Text TextMoney;
    [SerializeField] PlayerStats _pStats;


    public void Update()
    {
        TextMoney.text = _pStats.Money.ToString();
    }
}
