using System.Collections;
using UnityEngine;

/// <summary>
/// Gere l'horloge
/// </summary>

public class Clock : MonoBehaviour
{
    float AnimationDuration = 1.0f;
    private void UpdateVisuals() { if(enabled) StartCoroutine(MoveNeedle()); }
    private void Start()
    {
        TimeManager.Instance.OnHour += UpdateVisuals; 
    }

    IEnumerator MoveNeedle()
    {
        float endTime = Time.time + AnimationDuration;

        Quaternion targetRotation = Quaternion.Euler(0,0,- (TimeManager.Instance.Hour%12)/12f * 360f+90f);
        Quaternion BaseRotation = transform.rotation;
        while (Time.time < endTime)
        {
            float alpha = 1f - (endTime - Time.time) / AnimationDuration;

            alpha = Mathf.SmoothStep(0, 1, alpha);
            transform.rotation = Quaternion.Lerp(BaseRotation, targetRotation, alpha);

            yield return 0;
        }
        transform.rotation = targetRotation;
    }
}
