using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class grassVFX : MonoBehaviour
{
    [SerializeField] VisualEffect vfx;
    [SerializeField] GroundEffect groundEffect;
    [SerializeField] float MaxRate = 32;

    bool isPlaying = false;
    public void UpdateVFXRate()
    {
        vfx.SetFloat("Rate", MaxRate* groundEffect.textureValues[1]);
    }

    private void Start()
    {
       vfx.Stop();
    }

    private void Update()
    {
        if (PlayerMain.Instance.InputManager.moveInput == Vector2.zero) { vfx.Stop(); isPlaying = false;/*print("ta ûte la mere");*/ } else if(!isPlaying) { vfx.Play(); isPlaying = true; }
    }
}
