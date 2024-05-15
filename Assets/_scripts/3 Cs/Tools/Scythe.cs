using UnityEngine;
using UnityEngine.Experimental.Audio;

public class Scythe : Tool
{
    AudioClip[] _cutsounds;

    /// <summary>
    /// gère les différentes possibilités lors de l'utilisation
    /// </summary>
    public override void Use()
    {
        base.Use();
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.TryGetComponent<PlantMain>(out PlantMain plantMain)) // si c'ets une plante
            {
                if (plantMain.PlantField == null) return;
                SFXManager.Instance.PlaySFXClip(_cutsounds, transform, 1f);
                plantMain.Harvest.Harvest(); // récolte la plante
            }
        }
    }
}
