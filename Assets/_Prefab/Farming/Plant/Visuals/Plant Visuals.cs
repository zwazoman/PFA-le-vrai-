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

    [Header("corrupted")]
    [SerializeField] Vector3 corrupted_scale;

    [Header("Middle")]
    [SerializeField] Vector3 middle_scale;

    [Header("pure")]
    [SerializeField] Vector3 pure_scale;
    [SerializeField] public VisualEffect sparkleVFX;

    [Header("rotation")]
    [SerializeField] float rotationChangeRate;
    float rotationOffset;

    [Header("Colors")]
    [GradientUsage(true)] //tema la syntax de merde https://docs.unity3d.com/ScriptReference/GradientUsageAttribute.html
    [SerializeField] Gradient orbColorOverLife;

    [SerializeField] AnimationCurve animationCurve;

    [SerializeField] PlantMain _main;
    
    
    
    private void Start()
    {
        rotationOffset = Random.value*360;

        //animation du scale pour donner l'impression qu'elle sort du sol
        StartCoroutine(Nathan.InterpolateOverTime(0, 1,.5f, (float interpolatedValue) => transform.localScale = Vector3.one * interpolatedValue , (float alpha) => { return /*Mathf.SmoothStep(0, 1, alpha)*/animationCurve.Evaluate(alpha); }));

        sparkleVFX.Stop();
    }

    private void OnValidate()
    {
        UpdateVisuals(AnimationValue);
    }


    public void UpdateVisuals(float newValue)
    {
        if(isActiveAndEnabled) /*if(Application.isPlaying)*/ StartCoroutine(Nathan.InterpolateOverTime(AnimationValue, newValue, .5f, (float interpolatedValue) => applyVisuals(interpolatedValue), (float alpha) => { return animationCurve.Evaluate(alpha); },()=>AnimationValue = newValue));//t'inquiete

        if (_main.Harvest.isHarvesteable) sparkleVFX.Play(); else sparkleVFX.Stop(); //vfx quand la plante peut etre récoltée.

    }

    void applyVisuals(float newValue) //appelé dans la coroutine
    {
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

}
