using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// Gere l'horloge
/// </summary>

public class Clock : MonoBehaviour
{
    [SerializeField] TMP_Text Compteur;
    float AnimationDuration = 1.0f;
    private void UpdateVisuals() 
    { 
        if (isActiveAndEnabled) {
            StopAllCoroutines(); 
            StartCoroutine(MoveNeedle());
            if (TimeManager.Instance.Hour == 24)
            {
                Compteur.text = "00h";
            }
            else
            {
                Compteur.text = TimeManager.Instance.Hour.ToString() + "h";
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -(TimeManager.Instance.Hour % 24f) / 24f * 360f + 90f);
            Compteur.text =  TimeManager.Instance.Hour.ToString() + "h";
        }
    }
    private void Start()
    {
        TimeManager.Instance.OnHour += UpdateVisuals; 
    }

    IEnumerator MoveNeedle()
    {
        float endTime = Time.time + AnimationDuration;

        Quaternion targetRotation = Quaternion.Euler(0,0,- (TimeManager.Instance.Hour%24f)/24f * 360f+90f);
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
