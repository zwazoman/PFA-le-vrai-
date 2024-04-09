using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    /// <summary>
    /// Gére le temp du jeu
    /// </summary>
   
    int _day;
    static float hour;
    float _minute;
    public UnityEvent _tenHour;

    private void Awake()
    {
        _day = 0;
        _minute = 0;
        hour = 0;
    }

    private void Start()
    {
        StartCoroutine(DayPass());
    }
    IEnumerator DayPass()
    {
        yield return new WaitForSeconds(2);
        hour ++;
        StartCoroutine(DayPass());
        _tenHour.Invoke();
        if (hour == 24)
        {
            _day ++;
            hour = 0;
            Debug.Log(_day);
        }
        Debug.Log(hour);
    }
}
