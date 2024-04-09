using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTime : MonoBehaviour
{
    [SerializeField] TimeManager _timeManager;

    private void Start()
    {
        
    }

    public void OnTenHour(int hour)
    {
        if (hour == 10)
        {
            Debug.Log("Il est 10h fdp");
        }
    }
}
