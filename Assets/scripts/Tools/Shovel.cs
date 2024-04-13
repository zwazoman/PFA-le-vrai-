using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Shovel : Tool
{

    [SerializeField] float _plantJumpForce;
    public override void Use()
    {
        base.Use();
        foreach(var hitCollider  in hitColliders)
        {
            if(hitCollider.TryGetComponent<PlantMain>(out PlantMain plantMain)) // si c'est une plante
            {
                //plantMain.gameObject.transform.parent = null; // détache la plante du champ
                plantMain.PlantField.IsEmpty = true;
                plantMain.PlantField.Plow();
                Rigidbody plantRb = plantMain.gameObject.AddComponent<Rigidbody>(); // ajoute un rigidbody a la plante
                plantMain.gameObject.AddComponent<Plant>(); // ajoute le component Item a la plante
                Vector3 direction = new Vector3(Random.Range(-0.2f, 0.2f), 0.5f, Random.Range(-0.2f, 0.2f));
                plantRb.AddForce(direction * _plantJumpForce, ForceMode.Impulse); // fait sauter la plante
                plantMain.PlantField = null;
            }
        }
    }
}
