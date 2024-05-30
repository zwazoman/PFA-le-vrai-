using System;
using UnityEngine;

/// <summary>
/// gère les objets cassables
/// </summary>
public class Breakable : Item
{
    [field : SerializeField]
    public bool HoeCantBreak { get; private set; }

    [SerializeField] AudioClip[] _breakSound;
    [SerializeField] float _breakSoundVolume = 1f;


    public override void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// appelé quand les hps de l'objet atteignent 0
    /// </summary>
    /// 
 public virtual void Break()
    {
        if(_breakSound != null) SFXManager.Instance.PlaySFXClip(_breakSound, transform.position, _breakSoundVolume);
        Destroy(gameObject);
    }
}
