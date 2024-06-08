using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class eve_animationEventReceiver : MonoBehaviour
{
    public UnityEvent onAnimationEnd;
    public void TriggerOnAnimationEnd() => onAnimationEnd.Invoke();
}
