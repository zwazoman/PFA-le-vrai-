using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameplayPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMoney;
    [SerializeField] private GameObject _UiWheelbarrow;
    [SerializeField] private GameObject _UiWalk;

    [SerializeField] private MoneyCounter MoneyCounter;
    
    public void UpdateDisplay(float from, float to)
    {
        MoneyCounter.SetMoney(to);
    }

    public void Start()
    {
        _textMoney.text = PlayerMain.Instance.Stats.Money.ToString();
    }

    public void Display(float current,float target)
    {
        DOVirtual.Float(current, target, 0.5f, (x) =>
        {
            current = x;
        }).OnComplete(() => { Display(current, target); });
    }

    public void SwitchUI()
    {
        if (_UiWalk.activeInHierarchy)
        {
            _UiWalk.SetActive(false);
            _UiWheelbarrow.SetActive(true);
        }
        else if (_UiWheelbarrow.activeInHierarchy)
        {
            _UiWheelbarrow.SetActive(false);
            _UiWalk.SetActive(true);
        }       
    }   
}

