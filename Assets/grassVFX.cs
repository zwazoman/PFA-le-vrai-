using UnityEngine;
using UnityEngine.VFX;

public class grassVFX : MonoBehaviour
{
    [SerializeField] VisualEffect vfx;
    [SerializeField] GroundEffect groundEffect;
    [SerializeField] float MaxRate = 32;

    public void UpdateVFXRate()
    {
        vfx.SetFloat("Rate", MaxRate* groundEffect.textureValues[1]);
    }

}
