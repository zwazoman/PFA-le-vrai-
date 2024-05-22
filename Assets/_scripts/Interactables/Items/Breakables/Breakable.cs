using System;
using UnityEngine;

/// <summary>
/// gère les objets cassables
/// </summary>
public class Breakable : Item
{
    public int Maxhp { get; protected set; }

    [field : SerializeField]
    public bool HoeCantBreak { get; private set; }

    [SerializeField] AudioClip[] _breakSound;
    [SerializeField] float _breakSoundVolume = 1f;

    private int _hp;

    private void Awake()
    {
        _hp = Maxhp;
    }

    /// <summary>
    /// appelé par le moulin et la houe. retire des hp a l'objet. s'ils atteignent 0 : appelle break
    /// </summary>
    /// <param name="breakPower"></param>
    public void SetBreak(int breakPower)
    {
        _hp -= breakPower;
        if(_hp <= 0)
        {
            Break();
        }
    }
    /// <summary>
    /// appelé quand les hps de l'objet atteignent 0
    /// </summary>
    /// 
 protected virtual void Break()
    {
        if(_breakSound != null) SFXManager.Instance.PlaySFXClip(_breakSound, transform, _breakSoundVolume);
        Destroy(gameObject);
    }
}
