using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WateringStorage : MonoBehaviour
{
    public int WaterStorage { get; private set; }
    public int MaxWaterStorage { get;set; }

    [SerializeField] AnimationCurve _tweenCurve;
    [SerializeField] Image _wateringBar;
    [SerializeField] float _animTime = 2;


    float _startTime = 3;


    private void Awake()
    {
        MaxWaterStorage = 10;
        WaterStorage = MaxWaterStorage;
    }

    public void Replenish()
    {
        WaterStorage = MaxWaterStorage;
        StopAllCoroutines();
        StartCoroutine(UpdateUI(WaterStorage));
    }

    public void Drain(int usedWater = 1)
    {
        WaterStorage -= usedWater;
        StopAllCoroutines();
        StartCoroutine(UpdateUI(WaterStorage));
    }

    private IEnumerator UpdateUI(int newWaterAmount) // comment on reset le temps ? c'est chiantos
    {
        //_wateringBar.DOFade(255, _animTime);
        print("suuu");
        _startTime = Time.time;
        _wateringBar.enabled = true;
        float targetFillAmount = Mathf.InverseLerp(0, MaxWaterStorage, newWaterAmount);
        _wateringBar.DOFillAmount(targetFillAmount, _animTime).SetEase(_tweenCurve);
        yield return new WaitUntil(() => { return Time.time > _startTime + 1.5f; });
        _wateringBar.enabled = false;
        //_wateringBar.DOFade(0, _animTime);
    }

}
