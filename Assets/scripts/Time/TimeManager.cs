using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Gére le temp du jeu
/// </summary>
public class TimeManager : MonoBehaviour
{
    public int Day;
    public float Hour;
    //float _minute;
    public UnityEvent _eventHour;
    public UnityEvent _eventDay;
    [SerializeField] float IrlSecond;

    public static TimeManager Instance { get;private set; }
    private void Awake()
    {
        if(Instance != null) Destroy(gameObject); //le singleton du bled
        Instance = this;


        Day = 1;
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
