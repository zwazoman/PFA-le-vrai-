using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RumbleManager : MonoBehaviour
{
    public static RumbleManager instance;

    private Gamepad _pad;
    private Coroutine _stopRumbleAfterTimeCoroutine;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void RumblePulse(float lowFrenquency,float highFrenquency, float duration)
    {
        _pad = Gamepad.current;

        if (_pad != null)
        {

            _pad.SetMotorSpeeds(lowFrenquency, highFrenquency);
            StartCoroutine(StopRumble(duration, _pad));
        }
    }

    private IEnumerator StopRumble(float duration, Gamepad pad)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        pad.SetMotorSpeeds(0f,0f);

    }
}
