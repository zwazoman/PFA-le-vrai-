using System;
using System.Threading.Tasks;
using UnityEngine;

public class Lever : Interactable
{
    [SerializeField] Mill _mill;
    [SerializeField] cogWheel firstCogWheel;
    [SerializeField] float minWheelAngle, maxWheelAngle;
    [SerializeField] Transform Levier;

    [SerializeField] Material mat_Impact;

    [Header("SFXs")]
    [SerializeField] AudioClip[] _millChargeSound;
    [SerializeField] float _millChargeSoundVolume = 1f;

    [SerializeField] AudioClip[] _rechargeSound;
    [SerializeField] float _rechargeSoundVolume = 1f;


    /// <summary>
    /// utiliser setAngle
    /// </summary>
    [SerializeField] AnimationCurve curve;
    bool canUse = true;
    protected override void Interaction()
    {
        if(!canUse) return;
        canUse = false;
        SFXManager.Instance.PlaySFXClip(_millChargeSound, transform.position, _millChargeSoundVolume);
        
        StartCoroutine(Nathan.InterpolateOverTime(0, 1, .8f, (float a) => { Levier.localRotation = Quaternion.LerpUnclamped(Quaternion.Euler(-90, 0, 0), Quaternion.Euler(-156, 0, 0),1f- ( a *2-1) * (a * 2 -1)); }));
        StartCoroutine(Nathan.InterpolateOverTime(0, 1, .75f, updateWheelRotation, (float a) => { return curve.Evaluate(a); },()=> { _ = mesCouilles(); }, true));
        
    }

    void updateWheelRotation(float t)
    {
        firstCogWheel.setAngle(Mathf.LerpUnclamped(minWheelAngle, maxWheelAngle, t));
    }

    private async Task mesCouilles()
    {
        try
        {
            await _mill.Crush();
        }
        catch (ArgumentException e)
        {
            print("oskour : " + e.Message);
        }
       
        //_= _mill.Crush();
        //await Task.Delay(_mill._collList.Count*100);

        //sound effect pshhh peshh et feedbacks
        //StartCoroutine(Nathan.InterpolateOverTime(0, 100, .5f, (float a) => mat_Impact.SetFloat("_animationValue",a)));
        await Task.Delay(500);
        SFXManager.Instance.PlaySFXClip(_rechargeSound, transform.position, _rechargeSoundVolume);
        StartCoroutine(Nathan.InterpolateOverTime(1, 0, 1.5f, updateWheelRotation,Nathan.SmoothStep01,()=>canUse=true, true));
    }


}
