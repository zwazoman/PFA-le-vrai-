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
        float min = -1;
        Field closest = null;
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<Field>(out Field field)) // si c'est un champ
            {
                Vector3 distance = field.gameObject.transform.position - transform.position; // distance entre l'objet et le joueur
                if (distance.sqrMagnitude < min || closest == null)
                {
                    min = distance.sqrMagnitude;
                    closest = field;
                }
            }

            if (hitCollider.gameObject.TryGetComponent<Breakable>(out Breakable breakable)) // si c'est un objet cassable
            {
                breakable.Break(); // casse l'objet
            }
        }
        if(closest != null && !closest.Sowable) closest.Plow(); // retourne le champ
    }
}