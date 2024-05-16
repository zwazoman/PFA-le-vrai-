using System.Threading.Tasks;
using UnityEngine;

public class Lever : Interactable
{
    [SerializeField] Mill _mill;
    [SerializeField] cogWheel firstCogWheel;
    [SerializeField] float minWheelAngle, maxWheelAngle;

    /// <summary>
    /// utiliser setAngle
    /// </summary>
    [SerializeField] AnimationCurve curve;
    bool canUse = true;
    protected override void Interaction()
    {
        print("ta pute");
        canUse = false;
        StartCoroutine(Nathan.InterpolateOverTime(0, 1, .8f, updateWheelRotation, (float a) => { return curve.Evaluate(a); },()=> { print("salope  "); ; _ = mesCouilles(); }, true));
        //animation de con
        
    }

    void updateWheelRotation(float t)
    {
        firstCogWheel.setAngle(Mathf.LerpUnclamped(minWheelAngle, maxWheelAngle, t));
    }

    private async Task mesCouilles()
    {
        print("la pute");
        _mill.Crush();
        //sound effect pshhh pshh

        await Task.Delay(300);
        StartCoroutine(Nathan.InterpolateOverTime(1, 0, 1.5f, updateWheelRotation,Nathan.SmoothStep01,()=>canUse=true, true));
    }


}
