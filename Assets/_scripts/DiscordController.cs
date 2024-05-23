using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;
using UnityEngine.InputSystem.Controls;

public class DiscordController : MonoBehaviour
{

    public Discord.Discord _discord { get;  set; }
    private long _time;
    // Start is called before the first frame update
    void Start()
    {
        _discord = new Discord.Discord(1243175969158598717, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = _discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Details = "R�colte des �mes",
            State = "",
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

    // Update is called once per frame
    void Update()
    {       
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
