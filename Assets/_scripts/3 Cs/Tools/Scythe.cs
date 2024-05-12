public class Scythe : Tool
{
    /// <summary>
    /// g�re les diff�rentes possibilit�s lors de l'utilisation
    /// </summary>
    public override void Use()
    {
        base.Use();
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.TryGetComponent<PlantMain>(out PlantMain plantMain)) // si c'ets une plante
            {
                if (plantMain.PlantField == null) return;
                plantMain.Harvest.Harvest(); // r�colte la plante
            }
        }
    }
}
