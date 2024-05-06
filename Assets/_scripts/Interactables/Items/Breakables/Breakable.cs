using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// gère les objets cassables
/// </summary>
public class Breakable : Item
{
    /// <summary>
    /// appelé quand l'objet reçoit un coup de houe : détruit l'objet
    /// </summary>
 public virtual void Break()
    {
        Destroy(gameObject);
    }
}
