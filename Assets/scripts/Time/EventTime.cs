using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTime : MonoBehaviour
{
    [SerializeField] TimeManager _timeManager;

    private void Start()
    {
        
    }

    void OnTenHour()
    {
        if (_timeManager.hour == 10)
        {
            Debug.Log("Il est 10h fdp");
        }
    }
}
