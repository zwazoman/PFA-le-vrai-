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


    public void PlayToolWooshSound()
    {
        SFXManager.Instance.PlaySFXClip(_toolWoosh, transform.position, _toolWooshVolume);
    }

    public void PlayHoeEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_hoeEquip, transform.position, _hoeEquipVolume);
    }

    public void PlayWateringCanEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_wateringCanEquip, transform.position, _wateringCanEquipVolume);
    }

    public void PlayWateringCanEmptyEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_wateringCanEmptyEquip, transform.position, _wateringCanEmptyEquipVolume);
    }

    public void PlayWateringActionSound()
    {
        SFXManager.Instance.PlaySFXClip(_wateringAction, transform.position, _wateringActionVolume);
    }

    public void PlayWateringEmpty()
    {
        SFXManager.Instance.PlaySFXClip(_wateringEmpty, transform.position, _wateringEmptyVolume);
    }

    public void PlayScytheEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_scytheEquip, transform.position, _scytheEquipVolume);
    }




    public void PlayWalkFootstepSound()
    {
        SFXManager.Instance.PlaySFXClip(_rockWalkFootsteps, transform.position, _rockWalkFootstepsVolume * PlayerMain.Instance.GroundEffect.textureValues[0]);
        SFXManager.Instance.PlaySFXClip(_grassWalkFootsteps, transform.position, _grassWalkFootstepsVolume * PlayerMain.Instance.GroundEffect.textureValues[1]);
    }

    public void PlayRunFootstepSound()
    {
        SFXManager.Instance.PlaySFXClip(_rockRunFootsteps, transform.position, _rockRunFootstepsVolume * PlayerMain.Instance.GroundEffect.textureValues[0]);
        SFXManager.Instance.PlaySFXClip(_grassRunFootsteps, transform.position, _grassRunFootstepsVolume * PlayerMain.Instance.GroundEffect.textureValues[1]);
    }




    public void PlayPickupPopSound()
    {
        SFXManager.Instance.PlaySFXClip(_pickupPop, transform.position, _pickupPopVolume);
    }

    public void PlayDropPopSound()
    {
        SFXManager.Instance.PlaySFXClip(_dropPop, transform.position, _dropPopSound);
    }

    public void PlayBuySOund()
    {
        SFXManager.Instance.PlaySFXClip(_buySound, transform.position, _buySoundVolume);
    }

}
