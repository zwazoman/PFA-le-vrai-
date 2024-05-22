using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Gére le temp du jeu
/// </summary>
public class TimeManager : MonoBehaviour
{
    public int Day {  get; private set; }
    public float Hour;// { get; private set; }
    //float _minute;
    public event Action OnHour;
    public event Action OnDay;
    [SerializeField] float _irlHourDuration;
    public float IrlHourDuration=>_irlHourDuration;

    //singleton
    private static TimeManager instance = null;
    public static TimeManager Instance => instance;

    //pause
    public bool isPaused=false;
    float LastRealTickTime; //ces deux valeurs sont utilisées pour pouvoir mettre en pause le jeu, et reprendre en tenant compte du temps qui s'etait deja ecoulé entre deux heures.
    float lastRealPauseTime;
    
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

    public void Init() => StartCoroutine(_init());

    private IEnumerator _init()
    {
        InvokeRepeating(nameof(TimePass), 0, _irlHourDuration); //repete la fonction TimePass
        yield return 0;
        OnHour.Invoke();//premiere heure
    }

    private void Start()
    {
        Init();
    }
    private void TimePass() //gere le temps en seconde irl pour 1h ig
    {
        LastRealTickTime = Time.time;

        Hour++;
        OnHour?.Invoke();

        //print($"heure : {Hour} , day : {Day}");

        if (Hour >= 24)
        {
            //print("a whole day has passed!");
            Day++;
            Hour = 0;
            OnDay?.Invoke();
        }
    }

    public void SkipTime(float timeToSkip)
    {
        CancelInvoke(nameof(TimePass));

        int i = 0;
        //for (int i = 0; i > timeToSkip; i++, CancelInvoke(nameof(TimePass)), Start()) ;
        while (i < timeToSkip)
        {            
            TimePass();
            i++;
            print(i);
        }

        InvokeRepeating(nameof(TimePass), _irlHourDuration, _irlHourDuration); 
    }

    public void SkipTo(int hourToGo)
    {
        SkipTime(24 - Hour + hourToGo);
    }


    //-Pause-
    public void pauseTime()
    {
        if (isPaused ) return;
        lastRealPauseTime= Time.time;
        CancelInvoke(nameof(TimePass));
        isPaused = true;
    }

    public void resume()
    {
        if (!isPaused) return;

        isPaused = false;

        float elapsedTime = lastRealPauseTime-LastRealTickTime;
        float remainingTime = _irlHourDuration - elapsedTime;

        LastRealTickTime = Time.time;
        print($"elapsedTime : {elapsedTime} ; remainingTime : {remainingTime}");
        InvokeRepeating(nameof(TimePass), remainingTime, _irlHourDuration);
    }


}
