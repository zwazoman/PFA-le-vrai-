using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : Tool
{
    /// <summary>
    /// gère les différentes possibilités lors de l'utilisation
    /// </summary>
    public override void Use()
    {
        base.Use();
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<Field>(out Field field)) // si c'est un champ
            {
                if (field.Sowable) return; // si le champ est déjà retourné on stoppe
                field.Plow(); // retourne le champ
            }
            /*
             * if (hitCollider.gameObject.TryGetComponent<Breakable>(out Breakable breakable)) // si c'est un objet cassable
            {
                breakable.Break() // casse l'objet
            }
            */
        }
    }
}