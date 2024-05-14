using UnityEngine;

public class TimeRelativeLight : MonoBehaviour
{
    [SerializeField] Light _light;

    [SerializeField] float MaxIntensity = 180;
    private void Start()
    {
        TimeManager.Instance.OnHour += OnHour;
    }

    void OnHour()
    {
        StartCoroutine( Nathan.InterpolateOverTime(Mathf.Abs((TimeManager.Instance.Hour -1) % 24f / 12f - 1f), Mathf.Abs((TimeManager.Instance.Hour) % 24f / 12f - 1f), 1, (a) => { _light.intensity = MaxIntensity * a * a; }, (a) => {return Mathf.SmoothStep(0, 1, a); },null)); //moi je bande
       
    }
}
