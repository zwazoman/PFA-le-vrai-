using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    int money;
    [SerializeField] TMP_Text text;

    [SerializeField] AnimationCurve scaleCurve;
    float scale = 1;

    private void Start()
    {
        money = PlayerMain.Instance.Stats.Money;
        text.text = money.ToString();
    }
    public void SetMoney(float to)
    {
        StartCoroutine(Nathan.InterpolateOverTime(money, to, 0.5f, ApplyText, Nathan.SmoothStep01));
    }

    void applyScale(float a)
    {
        scale = Mathf.Lerp(scale, 1, scaleCurve.Evaluate(a));
        transform.localScale = Vector3.one * scale;
    }

    void ApplyText(float a)
    {
        money = (int) a;
        text.text = money.ToString();
    }
}
