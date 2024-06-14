using UnityEngine;

public class DiscordController : MonoBehaviour
{

    public Discord.Discord _discord { get;  set; }
    private long _time;
    private static DiscordController instance = null;
    public static DiscordController Instance => instance;
    private int _day;

    private void Awake()
    { 
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

    void Start()
    {
        DontDestroyOnLoad(this);
        _time = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
        _discord = new Discord.Discord(1243175969158598717, (System.UInt64)Discord.CreateFlags.Default); //Connexion a l'app de Discord
        var activityManager = _discord.GetActivityManager();
        var activity = new Discord.Activity //Activiter visible sur discord 
        {   
            State = "Récolte des âmes",
            //Details = $"Jour {TimeManager.Instance.Day}",           
            Timestamps = { Start = _time}
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
                Debug.Log("Discord status set !");
            else
                Debug.LogError("Discord status failed");
        });
    }

    void Update()
    {       
        //verifier si discord est lancé
        try
        {
            _discord.RunCallbacks();
        }
        catch 
        { 
            Destroy(gameObject);
        }
    }
}
