using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    /// <summary>
    /// Gére le temp du jeu
    /// </summary>

    public static int Day;
    public static float Hour;
    //float _minute;
    [SerializeField] UnityEvent _eventHour;
    [SerializeField] UnityEvent _eventDay;
    [SerializeField] float IrlSecond;

    private void Awake()
    {
        Day = 1;
        //_minute = 0;
        Hour = 0;
    }

    private void Start()
    {
        InvokeRepeating("TimePass", IrlSecond, IrlSecond);
    }
    private void TimePass() //gere le temps en seconde irl pour 1h ig
    {
        Hour++;
        _eventHour.Invoke();
        Debug.Log(Hour);

        if (Hour == 24)
        {
            Day++;
            Hour = 0;
            _eventDay.Invoke();
            Debug.Log(Day);
        }
    }
}
