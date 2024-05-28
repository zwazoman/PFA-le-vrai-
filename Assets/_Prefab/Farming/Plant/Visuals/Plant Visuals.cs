using UnityEngine;
using UnityEngine.VFX;

/// <summary>
/// Ce script gere le visuel de la plante en fonction de son niveau de corruption.
/// </summary>
public class PlantVisuals : MonoBehaviour
{
    [SerializeField][Range(0, 1)] float AnimationValue;

    [Header("References")]
    [SerializeField] SkinnedMeshRenderer mesh;
    [SerializeField] GameObject visuals;
    [SerializeField] PlantMain _main;

    [Header("corrupted")]
    [SerializeField] Vector3 corrupted_scale;

    [Header("Middle")]
    [SerializeField] Vector3 middle_scale;

    [Header("pure")]
    [SerializeField] Vector3 pure_scale;

    [Header("rotation")]
    [SerializeField] float rotationChangeRate;
    float rotationOffset;

    [Header("Colors")]
    [GradientUsage(true)] //tema la syntax de merde https://docs.unity3d.com/ScriptReference/GradientUsageAttribute.html
    [SerializeField] Gradient orbColorOverLife;

    [Header("VFX")]
    [SerializeField] public VisualEffect sparkleVFX;
    [SerializeField] public VisualEffect DyingVFX;
    [SerializeField] VisualEffect splashVFX;

    [Header("SFX")]
    [SerializeField] AudioClip[] _wateredSound;
    [SerializeField] float _wateredVolume = 1f;

    [SerializeField] AnimationCurve animationCurve;

    

    float CurrentSaturation = 1;

    private void Start()
    {
        rotationOffset = Random.value*360;

        //animation du scale pour donner l'impression qu'elle sort du sol
        StartCoroutine(Nathan.InterpolateOverTime(0, 1,.5f, (float interpolatedValue) => transform.localScale = Vector3.one * interpolatedValue , (float alpha) => { return /*Mathf.SmoothStep(0, 1, alpha)*/animationCurve.Evaluate(alpha); }));

        DyingVFX.playRate = 1.5f;
        sparkleVFX.Stop();
        splashVFX.Stop();




    }

    private void OnValidate()
    {
        UpdateVisuals(AnimationValue);
    }


    public void UpdateVisuals(float newValue)
    {
        if(isActiveAndEnabled) /*if(Application.isPlaying)*/ StartCoroutine(Nathan.InterpolateOverTime(AnimationValue, newValue, .5f, (float interpolatedValue) => applyVisuals(interpolatedValue), (float alpha) => { return animationCurve.Evaluate(alpha); },()=>AnimationValue = newValue));//t'inquiete

        if (_main.Harvest.isHarvesteable) sparkleVFX.Play(); else sparkleVFX.Stop(); //vfx quand la plante peut etre récoltée.
        
        if (_main.CanWater && !_main.Harvest.isHarvesteable)//vfx quand la plante se corromp.car elle n'a pas été arrosée
        {
            StartCoroutine(Nathan.InterpolateOverTime(CurrentSaturation, .4f, .5f, (float a) => {
                CurrentSaturation = a;
                MaterialPropertyBlock BodyProperties = new();
                BodyProperties.SetFloat("_Saturation", CurrentSaturation);
                mesh.SetPropertyBlock(BodyProperties, 0);
            }, Nathan.SmoothStep01)); 
            
            DyingVFX.Play();
        }
        else
        {
            StartCoroutine(Nathan.InterpolateOverTime(CurrentSaturation,1.1f, .5f, (float a) => { 
                CurrentSaturation = a;
                MaterialPropertyBlock BodyProperties = new();
                BodyProperties.SetFloat("_Saturation", CurrentSaturation);
                mesh.SetPropertyBlock(BodyProperties, 0);
            }, Nathan.SmoothStep01));

            DyingVFX.Stop();
        } 

    }

    void applyVisuals(float newValue) //appelé dans la coroutine
    {
        newValue = Mathf.Pow(newValue, 1.2f);

        //mesh
        mesh.SetBlendShapeWeight(0, Mathf.Clamp01(newValue * 2) * 100);
        mesh.SetBlendShapeWeight(1, Mathf.Clamp01(newValue * 2 - 1) * 100);

        //scale
        visuals.transform.localScale = lerpScale(newValue);

        //rotation
        visuals.transform.localEulerAngles = Vector3.up * (rotationChangeRate * newValue + rotationOffset);

        //orbColor
        MaterialPropertyBlock properties = new();
        properties.SetColor("_Color", orbColorOverLife.Evaluate(newValue));
        mesh.SetPropertyBlock(properties, 1);
    }

    private Vector3 lerpScale(float alpha)
    {
        if (alpha <= 0.5f)
        {
            return Vector3.Lerp(corrupted_scale, middle_scale, /*Mathf.Clamp01(*/alpha * 2);
        }
        else
        {
            return Vector3.Lerp(middle_scale, pure_scale, /*Mathf.Clamp01(*/alpha * 2 - 1);
        }
    }

    public void PlayWateredAnimation()
    {
        //--- ton son ici Nestor ---
        //--- merci mon frère ---

        SFXManager.Instance.PlaySFXClip(_wateredSound, transform.position, _wateredVolume);
        
        StartCoroutine(Nathan.ExecuteWithDelay(() => { splashVFX.Play(); /*ou bien ici si tu veux que ça soit au milieu de l'animation*/    }, .25f));
        StartCoroutine(Nathan.InterpolateOverTime(0, 1, .5f, applyWaterAnimation, (float a) =>{return a;},OnWateringAnimationEnd));
    }

    void OnWateringAnimationEnd()
    {
        transform.localScale = Vector3.one;
    }

    void applyWaterAnimation(float a)
    {
        //scale 
        transform.localScale = Vector3.one * (1f + Nathan.Parabola( a) * 0.3f);
        
        MaterialPropertyBlock dBodyProperties = new();
        dBodyProperties.SetFloat("_waterIntensity", (1f-  a)*(1f-a));
        mesh.SetPropertyBlock(dBodyProperties, 0);
    }
    

}
