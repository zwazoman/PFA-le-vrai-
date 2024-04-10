using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
    float AnimationDuration = 1.0f;
    private void UpdateVisuals() => StartCoroutine(MoveNeedle());
    private void Start()
    {
        TimeManager.Instance._eventHour.AddListener(UpdateVisuals); 
    }
    IEnumerator MoveNeedle()
    {
        float TimeAlpha = (float)TimeManager.Instance.Hour / 12f;
        float endTime = Time.time + AnimationDuration;

        Quaternion targetRotation = Quaternion.Euler(0,0, transform.eulerAngles.z + -360f / 12f);
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
