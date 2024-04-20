using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WateringStorage : MonoBehaviour
{
    public int MaxWaterStorage { get;set; }

    [SerializeField] AnimationCurve _tweenCurve;
    [SerializeField] Image _wateringBar;
    [SerializeField] float _animTime = 2;

    public int WaterStorage { get; private set; }

    private void Awake()
    {
        MaxWaterStorage = 10;
        WaterStorage = MaxWaterStorage;
    }

    public void Replenish()
    {
        WaterStorage = MaxWaterStorage;
        StartCoroutine(UpdateUI(WaterStorage));
    }

    public void Empty(int usedWater = 1)
    {
        WaterStorage -= usedWater;
        StartCoroutine(UpdateUI(WaterStorage));
    }

    private IEnumerator UpdateUI(int newWaterAmount) // comment on reset le temps ? c'est chiantos
    {
        //_wateringBar.DOFade(255, _animTime);
        _wateringBar.enabled = true;
        float targetFillAmount = Mathf.InverseLerp(0,MaxWaterStorage, newWaterAmount);
        _wateringBar.DOFillAmount(targetFillAmount, _animTime).SetEase(_tweenCurve);
        yield return new WaitForSeconds(_animTime +0.5f);
        _wateringBar.enabled = false;
        //_wateringBar.DOFade(0, _animTime);
    }
}
