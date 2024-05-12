using UnityEngine;

public class Shovel : Tool
{

    [SerializeField] float _plantJumpForce;

    /// <summary>
    /// g�re les diff�rentes possibilit�s lors de l'utilisation de l'arrosoir
    /// </summary>
    public override void Use()
    {
        base.Use();
        foreach(var hitCollider  in hitColliders)
        {
            if(hitCollider.TryGetComponent<PlantMain>(out PlantMain plantMain)) // si c'est une plante
            {
                if (plantMain.PlantField == null) return;
                plantMain.Unplant.Unplant();
            }
        }
    }
}
