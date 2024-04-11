using UnityEngine;
   /// <summary>
    /// Declenches des actions en fonction d'une certaine heure ou d'une certaine date
    /// </summary>
public class EventTime : MonoBehaviour
{
 
    public void EventAtHour()
    {
        if (TimeManager.Instance.Hour == 10)
        {
            Debug.Log("Il est 10h fdp");
        }
    }

    public void EventAtDay()
    {
        if (TimeManager.Instance.Day == 2)
        {
            Debug.Log("on est le Jour 2");
        }
    }
}
