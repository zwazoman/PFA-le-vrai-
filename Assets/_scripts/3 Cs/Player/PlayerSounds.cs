using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [Header("Hoe")]
    [SerializeField] AudioClip[] _hoeEquip;
    [SerializeField] float _hoeEquipVolume = 1f;

    [Header("Watering Can")] 
    [SerializeField] AudioClip[] _wateringCanEquip;
    [SerializeField] float _wateringCanEquipVolume = 1f;

    [SerializeField] AudioClip[] _wateringCanEmptyEquip;
    [SerializeField] float _wateringCanEmptyEquipVolume = 1f;

    [SerializeField] AudioClip[] _wateringAction;
    [SerializeField] float _wateringActionVolume = 1f;

    [SerializeField] AudioClip[] _wateringEmpty;
    [SerializeField] float _wateringEmptyVolume = 0.2f;

    [Header("Scythe")]
    [SerializeField] AudioClip[] _scytheEquip;
    [SerializeField] float _scytheEquipVolume = 1f;

    [Header("Footsteps")]
    [SerializeField] AudioClip[] _rockWalkFootsteps;
    [SerializeField] float _rockWalkFootstepsVolume = 1f;

    [SerializeField] AudioClip[] _rockRunFootsteps;
    [SerializeField] float _rockRunFootstepsVolume = 1f;

    [SerializeField] AudioClip[] _grassWalkFootsteps;
    [SerializeField] float _grassWalkFootstepsVolume = 1f;

    [SerializeField] AudioClip[] _grassRunFootsteps;
    [SerializeField] float _grassRunFootstepsVolume = 1f;

    [SerializeField] AudioClip[] _woodWalkFootsteps;
    [SerializeField] float _woodWalkFootstepsVolume = 1f;

    [SerializeField] AudioClip[] _woodRunFootsteps;
    [SerializeField] float _woodRunFootstepsVolume = 1f;

    [Header("Wooshes")]
    [SerializeField] AudioClip[] _toolWoosh;
    [SerializeField] float _toolWooshVolume = 1f;

    [Header("Other")]
    [SerializeField] AudioClip[] _pickupPop;
    [SerializeField] float _pickupPopVolume = 1f;

    [SerializeField] AudioClip[] _dropPop;
    [SerializeField] float _dropPopSound = 1f;

    [SerializeField] AudioClip[] _buySound;
    [SerializeField] float _buySoundVolume = 1f;

    [SerializeField] AudioClip[] _validateQuestSounds;
    [SerializeField] float _validateQuestSoundsVolume = 1f;


    public void PlayToolWooshSound()
    {
        SFXManager.Instance.PlaySFXClip(_toolWoosh, transform.position, _toolWooshVolume, false, true);
    }

    public void PlayHoeEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_hoeEquip, transform.position, _hoeEquipVolume, false, true);
    }

    public void PlayWateringCanEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_wateringCanEquip, transform.position, _wateringCanEquipVolume, false, true);
    }

    public void PlayWateringCanEmptyEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_wateringCanEmptyEquip, transform.position, _wateringCanEmptyEquipVolume, false, true);
    }

    public void PlayWateringActionSound()
    {
        SFXManager.Instance.PlaySFXClip(_wateringAction, transform.position, _wateringActionVolume, false, true);
    }

    public void PlayWateringEmpty()
    {
        SFXManager.Instance.PlaySFXClip(_wateringEmpty, transform.position, _wateringEmptyVolume, false, true);
    }

    public void PlayScytheEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_scytheEquip, transform.position, _scytheEquipVolume, false, true);
    }





    public void PlayFootstepSound()
    {
        if (PlayerMain.Instance.Movement.IsRunning)
        {
            PlayRunSound();
            return;
        }
        if (PlayerMain.Instance.GroundEffect.textureValues[0] > 0.2f) SFXManager.Instance.PlaySFXClip(_rockWalkFootsteps, transform.position, _rockWalkFootstepsVolume * PlayerMain.Instance.GroundEffect.textureValues[0], false, true);
        SFXManager.Instance.PlaySFXClip(_grassWalkFootsteps, transform.position, _grassWalkFootstepsVolume * PlayerMain.Instance.GroundEffect.textureValues[1], false, true);
        SFXManager.Instance.PlaySFXClip(_woodWalkFootsteps, transform.position, _woodWalkFootstepsVolume * PlayerMain.Instance.GroundEffect.textureValues[2], false, true);
    }

    private void PlayRunSound()
    {
        if (PlayerMain.Instance.GroundEffect.textureValues[0] > 0.2f) SFXManager.Instance.PlaySFXClip(_rockRunFootsteps, transform.position, _rockRunFootstepsVolume * PlayerMain.Instance.GroundEffect.textureValues[0],false,true);
        SFXManager.Instance.PlaySFXClip(_grassRunFootsteps, transform.position, _grassRunFootstepsVolume * PlayerMain.Instance.GroundEffect.textureValues[1]  , false, true);
        SFXManager.Instance.PlaySFXClip(_woodRunFootsteps, transform.position, _woodRunFootstepsVolume * PlayerMain.Instance.GroundEffect.textureValues[2], false, true);
    }





    public void PlayPickupPopSound()
    {
        SFXManager.Instance.PlaySFXClip(_pickupPop, transform.position, _pickupPopVolume,false,true);
    }

    public void PlayDropPopSound()
    {
        SFXManager.Instance.PlaySFXClip(_dropPop, transform.position, _dropPopSound, false, true);
    }

    public void PlayBuySound()
    {
        SFXManager.Instance.PlaySFXClip(_buySound, transform.position, _buySoundVolume, true, true);
    }

    public void PlayQuestValidateSound()
    {
        SFXManager.Instance.PlaySFXClip(_validateQuestSounds, transform.position, _validateQuestSoundsVolume, false,true);
    }

}
