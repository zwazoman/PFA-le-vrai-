using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class horairesPapillons : MonoBehaviour
{
    [SerializeField]
    VisualEffect papillons;
    float BaseRate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        TimeManager.Instance.OnHour += updateVisuals;
        BaseRate = papillons.GetFloat("Rate");
    }

    void updateVisuals()
    {
        papillons.SetFloat("Rate", Mathf.Pow(Mathf.Abs(TimeManager.Instance.Hour - 12) / 12f ,2f) * BaseRate);
    }
}
