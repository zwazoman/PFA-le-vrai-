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

    Coroutine u;

    private void Start()
    {
        money = PlayerMain.Instance.Stats.Money;
        text.text = money.ToString();
    }
    public void SetMoney(float to)
    {
        print("Vas y nath");
        if(isActiveAndEnabled)
        {
            StartCoroutine(Nathan.InterpolateOverTime(money, to, 0.5f, ApplyText, Nathan.SmoothStep01));
            if (u != null) StopCoroutine(u);
            u = StartCoroutine(Nathan.InterpolateOverTime(0, 1, 0.5f, applyScale, Nathan.SmoothStep01));
        }
        else
        {
            print("Salope de 4 couleurs");
            ApplyText(to);
        }
        
    }

    void applyScale(float a)
    {
        print("mes boules ");
        scale = Mathf.Clamp( Mathf.Lerp(scale, 1,a) + scaleCurve.Evaluate(a) ,1,1.8f);
        transform.localScale = Vector3.one * scale;
    }

    void ApplyText(float a)
    {
        money = (int) a;
        text.text = money.ToString();
    }
}
