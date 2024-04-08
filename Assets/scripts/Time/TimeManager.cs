using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    /// <summary>
    /// Gére le temp du jeu
    /// </summary>
   
    int _day;
    public float hour { get; private set; }
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
        if (hour == 24)
        {
            _day ++;
            hour = 0;
            Debug.Log(_day);
            _tenHour.Invoke();
        }
        Debug.Log(hour);
    }

    void OnTenHour(int _hour = 10)
    {
        Debug.Log("Il est 10h");
    }
}
