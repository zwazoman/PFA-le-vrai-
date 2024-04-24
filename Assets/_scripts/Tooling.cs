using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Plein de fonctions utiles
/// </summary>
public class Tooling : MonoBehaviour
{
    public static float DampFloat(float a, float b, float lambda)
    {
        return Mathf.Lerp(a, b, 1 - Mathf.Exp(-lambda * Time.deltaTime));
    }

    /// <summary>
    /// Dotween Wish.
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
            if (followGameTime && TimeManager.Instance.isPaused) endTime += Time.deltaTime;

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


    //https://learn.microsoft.com/en-US/dotnet/csharp/programming-guide/delegates/using-delegates
    public delegate void ValueSetter(float newValue);
    public delegate float AlphaInterpolation(float alpha);
}
