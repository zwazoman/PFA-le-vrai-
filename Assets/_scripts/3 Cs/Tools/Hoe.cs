using UnityEngine;
using UnityEngine.VFX;

public class Hoe : Tool
{
    public int breakPower { get; set; }

    [SerializeField] AudioClip[] _plowSounds;
    [SerializeField] float _plowVolume = 1f;

    [SerializeField] AudioClip[] _groundHitSounds;
    [SerializeField] float _groundHitVolume = 1f;

    [SerializeField] Transform _head;
    [SerializeField] GameObject groundHitVFXPrefab;
    private void Awake()
    {
        breakPower = 1;
    }

    /// <summary>
    /// gère les différentes possibilités lors de l'utilisation
    /// </summary>
    public override void Use()
    {
        base.Use();
        float min = -1;
        bool fieldHit = false;
        Field closest = null;
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<Field>(out Field field)) // si c'est un champ
            {
                fieldHit = true;
                Vector3 distance = field.gameObject.transform.position - transform.position; // distance entre l'objet et le joueur
                if (distance.sqrMagnitude < min || closest == null)
                {
                    min = distance.sqrMagnitude;
                    closest = field;
                }
            }

            if (hitCollider.gameObject.TryGetComponent<Breakable>(out Breakable breakable)) // si c'est un objet cassable
            {
                breakable.SetBreak(breakPower); // casse l'objet
            }
        }
        if (!fieldHit)
        {
            SFXManager.Instance.PlaySFXClip(_groundHitSounds, transform, _groundHitVolume);
            Destroy(Instantiate(groundHitVFXPrefab,_head.transform.position,Quaternion.identity),2);
        }
        else SFXManager.Instance.PlaySFXClip(_plowSounds, transform, _plowVolume);
        

        if(closest != null && !closest.Sowable)
        {
            closest.Plow(); // retourne le champ
        }
    }
}