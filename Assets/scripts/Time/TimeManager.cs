using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Gére le temp du jeu
/// </summary>
public class TimeManager : MonoBehaviour
{
    public int Day {  get; private set; }
    public float Hour { get; private set; }
    //float _minute;
    public UnityEvent _eventHour;
    public UnityEvent _eventDay;
    [SerializeField] float IrlSecond;

    //singleton
    private static TimeManager instance = null;
    public static TimeManager Instance => instance;

    private void Awake()
    {
        Day = 1;
        //_minute = 0;
        Hour = 0;

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
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

    public void SkipTime(float timeToSkip, int i)
    {
        //for (int i = 0; i > timeToSkip; i++, CancelInvoke(nameof(TimePass)), Start()) ;
        while (i < timeToSkip)
        {
            CancelInvoke(nameof(TimePass));
            Start();
            i++;
        }
    }
}
