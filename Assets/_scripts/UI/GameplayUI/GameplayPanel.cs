using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.InputSystem.XR.Haptics;

public class GameplayPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMoney;

    
    public void UpdateDisplay(float from, float to)
    {
        StartCoroutine(Nathan.InterpolateOverTime(from, to, 0.2f,UpdateText));
    }

    private void UpdateText(float newValue)
    {
        _textMoney.text = Mathf.Round(newValue).ToString();
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

    
}

