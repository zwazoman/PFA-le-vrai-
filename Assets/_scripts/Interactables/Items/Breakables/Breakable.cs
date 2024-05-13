using System;
using UnityEngine;

/// <summary>
/// g�re les objets cassables
/// </summary>
public class Breakable : Item
{
    public int maxhp { get; protected set; }

    private int hp;

    private void Awake()
    {
        hp = maxhp;
    }

    /// <summary>
    /// appel� par le moulin et la houe. retire des hp a l'objet. s'ils atteignent 0 : appelle break
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
    /// appel� quand les hps de l'objet atteignent 0
    /// </summary>
    /// 
 protected virtual void Break()
    {
        Destroy(gameObject);
    }
}
