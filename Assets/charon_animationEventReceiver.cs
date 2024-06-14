using UnityEngine;
using UnityEngine.Events;

public class charon_animationEventReceiver : MonoBehaviour
{
    public UnityEvent OnArrived;

    public void TriggerOnArrived() => OnArrived?.Invoke();

    public UnityEvent OnReadyToLeave;
    public void  TriggerOnReadyToLeave() => OnReadyToLeave?.Invoke();   
}
