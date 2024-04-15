using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// g�re les objets cassables
/// </summary>
public class Breakable : Item
{
    /// <summary>
    /// appel� quand l'objet re�oit un coup de houe : d�truit l'objet
    /// </summary>
 public virtual void Break()
    {
        Destroy(gameObject);
    }
}
