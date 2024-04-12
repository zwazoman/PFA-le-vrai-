using CustomInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

/// <summary>
/// cette classe gère la directional light de la scene: elle la fait tourner et en change la couleur en fonction du temps
/// </summary>
public class Sun : MonoBehaviour
{
    [SerializeField] float AnimationDuration = 1.0f;
    [SerializeField] Gradient Gradient = new Gradient();


    [SelfFill][SerializeField] Light _Light ;
    private void Awake()
    {
        TimeManager.Instance._eventHour.AddListener(UpdateVisuals);
        OnValidate();
    }

    private void OnValidate()
    {
        _Light.color = Gradient.Evaluate(0f);
    }
    private void UpdateVisuals() => StartCoroutine(MoveLight());

    /// <summary>
    /// Fait tourner la light `AnimationDuration` secondes de 1/24 degrés
    /// </summary>
    /// <returns></returns>
    IEnumerator MoveLight()
    {
        float TimeAlpha = (float)TimeManager.Instance.Hour / 24f;
        float endTime = Time.time + AnimationDuration;

        Quaternion targetRotation = Quaternion.Euler(60, transform.eulerAngles.y + 360f/24f,0);
        Quaternion BaseRotation = transform.rotation;
        while (Time.time<endTime)
        {
            float alpha = 1f - (endTime - Time.time)/AnimationDuration;
            
            alpha = Mathf.SmoothStep(0,1,alpha);
            transform.rotation = Quaternion.Lerp  (BaseRotation, targetRotation,alpha);

            _Light.color = Gradient.Evaluate(alpha/24f + ((float)TimeManager.Instance.Hour/24f)%1f);
            yield return 0;
        }
        transform.rotation = targetRotation;

    }


}
