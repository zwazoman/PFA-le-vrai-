using System;
using UnityEngine;

/// <summary>
/// gère les objets cassables
/// </summary>
public class Breakable : Item
{
    public int maxhp { get; protected set; }

    [SerializeField] AudioClip[] _breakSound;
    [SerializeField] float _breakSoundVolume = 1f;

    [SerializeField] AudioClip[] _effectSound;
    [SerializeField] float _effectSoundVolume = 1f;

    private int hp;

    private void Awake()
    {
        hp = maxhp;
    }

    /// <summary>
    /// appelé par le moulin et la houe. retire des hp a l'objet. s'ils atteignent 0 : appelle break
    /// </summary>
    /// <param name="breakPower"></param>
    public void SetBreak(int breakPower)
    {
        hp -= breakPower;
        if(hp <= 0)
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
        SFXManager.Instance.PlaySFXClip(_breakSound, transform, _breakSoundVolume);
        Destroy(gameObject);
    }
}
