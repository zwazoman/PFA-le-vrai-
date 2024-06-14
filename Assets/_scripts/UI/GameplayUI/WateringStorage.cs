using UnityEngine;
using UnityEngine.UI;

public class WateringStorage : MonoBehaviour
{
    public int WaterStorage { get; private set; }
    public bool CanWater => WaterStorage > 0;

    public int MaxWaterStorage;

    [SerializeField] AnimationCurve _tweenCurve;
    [SerializeField] Slider _wateringBar;
    [SerializeField] float _animTime = 2;


    float _startTime = 3;


    private void Awake()
    {
        WaterStorage = MaxWaterStorage;
    }

    public void Replenish()
    {
        StopAllCoroutines();
        UpdateUI(WaterStorage,MaxWaterStorage);
        WaterStorage = MaxWaterStorage;
        
    }

    public void Drain(int usedWater = 1)
    {
        if (WaterStorage <= 0) return;
        StopAllCoroutines();
        UpdateUI(WaterStorage, WaterStorage - usedWater);
        WaterStorage = Mathf.Max(0, WaterStorage - usedWater);
       
    }

    private void UpdateUI(int oldAmount,int newWaterAmount) // comment on reset le temps ? c'est chiantos
    {
        //_wateringBar.DOFade(255, _animTime);
        _startTime = Time.time;
        _wateringBar.enabled = true;

        float currentFillAmount = Mathf.InverseLerp(0, MaxWaterStorage, oldAmount);
        float targetFillAmount = Mathf.InverseLerp(0, MaxWaterStorage, newWaterAmount);

        _wateringBar.gameObject.SetActive(true);
        StartCoroutine(Nathan.InterpolateOverTime(currentFillAmount, targetFillAmount, _animTime, (float v) => { _wateringBar.value = v; },(float a)=> { return _tweenCurve.Evaluate(a); },()=> { _wateringBar.gameObject.SetActive(false); }));

        //_wateringBar.DOFillAmount(targetFillAmount, _animTime).SetEase(_tweenCurve);
        //yield return new WaitUntil(() => { return Time.time > _startTime + 1.5f; });
        
        //_wateringBar.DOFade(0, _animTime);
    }

}
