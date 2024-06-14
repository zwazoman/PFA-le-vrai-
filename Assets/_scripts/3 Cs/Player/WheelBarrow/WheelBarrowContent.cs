using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelBarrowContent : MonoBehaviour
{
    WheelBarrowStorage _storage;

    [SerializeField] AnimationCurve _tweenCurve;
    [SerializeField] Slider _storageBar;
    [SerializeField] float _animTime = 2f;

    float _startTime = 3;


    private void Awake()
    {
        _storage = GetComponent<WheelBarrowStorage>();
    }

    private void Start()
    {
        _storage.OnAdd += Add;
        _storage.OnRemove += Remove;
    }

    void Add()
    {
        StopAllCoroutines();
        UpdateUI(_storage.storageContent.Count -1, _storage.storageContent.Count);
    }

    void Remove()
    {
        StopAllCoroutines();
        UpdateUI(_storage.storageContent.Count, _storage.storageContent.Count - 1);
    }

    void UpdateUI(int oldAmount, int newAmount) // comment on reset le temps ? c'est chiantos
    {
        //_wateringBar.DOFade(255, _animTime);
        _startTime = Time.time;
        _storageBar.enabled = true;

        float currentFillAmount = Mathf.InverseLerp(0, _storage.MaxStorageWheelBarrow, oldAmount);
        float targetFillAmount = Mathf.InverseLerp(0, _storage.MaxStorageWheelBarrow, newAmount);

        _storageBar.gameObject.SetActive(true);
        StartCoroutine(Nathan.InterpolateOverTime(currentFillAmount, targetFillAmount, _animTime, (float v) => { _storageBar.value = v; }, (float a) => { return _tweenCurve.Evaluate(a); }, () => { _storageBar.gameObject.SetActive(false); }));

        //_wateringBar.DOFillAmount(targetFillAmount, _animTime).SetEase(_tweenCurve);
        //yield return new WaitUntil(() => { return Time.time > _startTime + 1.5f; });

        //_wateringBar.DOFade(0, _animTime);
    }
}
