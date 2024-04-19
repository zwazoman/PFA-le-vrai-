using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    
    [Header("rotation")]
    [SerializeField] float rotationChangeRate;
    float rotationOffset;

    [Header("Colors")]
    [GradientUsage(true)] //tema la syntax de merde https://docs.unity3d.com/ScriptReference/GradientUsageAttribute.html
    [SerializeField] Gradient orbColorOverLife;
    private void Start()
    {
        rotationOffset = Random.value*360;
    }

    private void OnValidate()
    {
        UpdateVisuals(AnimationValue);
    }

    public void UpdateVisuals(float newValue)
    {
        AnimationValue=newValue;

        //mesh
        mesh.SetBlendShapeWeight(0, Mathf.Clamp01( AnimationValue * 2)*100);
        mesh.SetBlendShapeWeight(1, Mathf.Clamp01( AnimationValue * 2 -1)*100);

        //scale
        if (AnimationValue <= 0.5f)
        {
            visuals.transform.localScale = Vector3.Lerp(corrupted_scale, middle_scale, Mathf.Clamp01(AnimationValue*2));
        }
        else
        {
            visuals.transform.localScale = Vector3.Lerp(middle_scale, pure_scale, Mathf.Clamp01(AnimationValue * 2-1));

        }

        //rotation
        visuals.transform.localEulerAngles = Vector3.up *( rotationChangeRate * AnimationValue+ rotationOffset);

        //orbColor
        MaterialPropertyBlock properties = new();
        properties.SetColor("_Color", orbColorOverLife.Evaluate(AnimationValue));
        mesh.SetPropertyBlock(properties, 1);
    }
}
