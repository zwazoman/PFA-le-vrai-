using UnityEngine;

public class EventTime : MonoBehaviour
{
    public void EventAtHour()
    {
        if (TimeManager.Hour == 10)
        {
            Debug.Log("Il est 10h fdp");
        }
    }

    public void EventAtDay()
    {
        if (TimeManager.Day == 2)
        {
            Debug.Log("on est le Jour 2");
        }
    }
}
