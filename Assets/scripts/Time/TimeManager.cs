using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Gére le temp du jeu
/// </summary>
public class TimeManager : MonoBehaviour
{
    public static int Day;
    public static float Hour;
    //float _minute;
    public UnityEvent _eventHour;
    public UnityEvent _eventDay;
    [SerializeField] float IrlSecond;

    private void Awake()
    {
        Day = 1;
        //_minute = 0;
        Hour = 0;
    }

    private void Start()
    {
        InvokeRepeating(nameof(TimePass), IrlSecond, IrlSecond); //repete la fonction TimePass
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

    public void SkipTime(float timeToSkip)
    {
        //for (int i = 0; i > timeToSkip; i++, CancelInvoke(nameof(TimePass)), Start()) ;
       // while ()
    }

    public void SkipTo()
    {

    }

}
