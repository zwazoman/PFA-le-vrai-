using UnityEngine;

public class Hoe : Tool
{
    int breakPower = 1;

    [SerializeField] AudioClip[] _plowSounds;
    [SerializeField] float _plowVolume = 1f;

    [SerializeField] AudioClip[] _groundHitSounds;
    [SerializeField] float _groundHitVolume = 1f;

    [SerializeField] Transform _head;
    [SerializeField] GameObject groundHitVFXPrefab;

    /// <summary>
    /// gère les différentes possibilités lors de l'utilisation
    /// </summary>
    public override void Use()
    {
        base.Use();
        float min = 50;
        bool fieldHit = false;
        Field closest = null;
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<Field>(out Field field)) // si c'est un champ
            {
                fieldHit = true;
                Vector3 distance = field.gameObject.transform.position - transform.position; // distance entre l'objet et le joueur
                if (distance.sqrMagnitude < min && !field.Sowable)
                {
                    min = distance.sqrMagnitude;
                    closest = field;
                }
            }
        }
        if (!fieldHit)
        {
            SFXManager.Instance.PlaySFXClip(_groundHitSounds, transform.position, _groundHitVolume, false, true);
            RumbleManager.instance.RumblePulse(0.8f, 0.8f, 0.2f); // fait vibrer la mannette
            Destroy(Instantiate(groundHitVFXPrefab,_head.transform.position,Quaternion.identity),2);
        }
        else SFXManager.Instance.PlaySFXClip(_plowSounds, transform.position, _plowVolume, false, true);
        

        if(closest != null && !closest.Sowable)
        {
            closest.Plow(); // retourne le champ
            RumbleManager.instance.RumblePulse(0.2f, 0.2f, 0.2f);// fait vibrer la mannette
        }
    }
}