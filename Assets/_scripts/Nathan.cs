using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Plein de fonctions utiles
/// </summary>
public class Nathan : MonoBehaviour
{
    public static float DampFloat(float a, float b, float lambda)
    {
        return Mathf.Lerp(a, b, 1 - Mathf.Exp(-lambda * Time.deltaTime));
    }

    /// <summary>
    /// Ce truc est une putain d'oeuvre d'art.
    /// Tu peux l'utiliser comme �a:
    /// StartCoroutine(Tooling.InterpolateOverTime(0, 1, .5f, (float interpolatedValue) => transform.localScale = Vector3.one * interpolatedValue , (float alpha) => { return alpha; }));
    /// </summary>
    /// <param name="from"> la valeur de d�part </param>
    /// <param name="to"> la valeur d'arriv�e </param>
    /// <param name="duration"> la dur�e de l'animation </param>
    /// <param name="valueSetter"> ce que tu veux faire de la valeur qu'il calcule � chaque tick </param>
    /// <param name="Interpolation"> une courbe d'interpolation avec une entr�e et une sortie entre 0 et 1 . tu peux faire smoothstep, mettre la valeur au carr� etc  </param>
    /// <returns></returns>
    public static IEnumerator InterpolateOverTime(float from, float to, float duration, ValueSetter valueSetter, AlphaInterpolation Interpolation = null, Action onEnd = null, bool followGameTime = false)
    {
        //pendant 'duration' secondes :
        float endTime = Time.time + duration;
        while (Time.time < endTime)
        {
            if ( followGameTime && TimeManager.Instance.isPaused) endTime += Time.deltaTime;

            //calculer l'alpha
            float alpha = 1 - (endTime - Time.time) / duration;
            if(Interpolation!=null) alpha = Interpolation(alpha);
            //alpha = Mathf.Clamp01(alpha);

            //lerp
            valueSetter(Mathf.LerpUnclamped(from, to, alpha));

            //attendre la frame suivante
            yield return null;
        }

        valueSetter(to);
        if(onEnd!=null) onEnd();
    }

    public static IEnumerator executeNextFrame(Action action)
    {
        yield return 0;
        action();
    }

    public static IEnumerator ExecuteWithDelay(Action action, float delay, bool followGameTime = false)
    {
        if (!followGameTime)
        {
            yield return new WaitForSeconds(delay);
        }
        else
        {
            float endTime = Time.time + delay;
            while (Time.time < endTime)
            {
                if (followGameTime && TimeManager.Instance.isPaused) endTime += Time.deltaTime;
                yield return null;
            }
        }

        action();
    }

    public static float SmoothStep01(float v)
    {
        return Mathf.SmoothStep(0,1,v);
    }

    public static float Linear(float v) => v;
    public static float Parabola(float v)
    {
        return 1f - (v * 2 - 1) * (v * 2 - 1);
    }


    //https://learn.microsoft.com/en-US/dotnet/csharp/programming-guide/delegates/using-delegates
    public delegate void ValueSetter(float newValue);
    public delegate float AlphaInterpolation(float alpha);
}
