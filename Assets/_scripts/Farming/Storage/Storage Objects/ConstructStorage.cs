using UnityEngine;

public class ConstructStorage : Storage
{
    [SerializeField] GameObject _fieldPrefab;

    [Header("SFX")]
    [SerializeField] AudioClip[] _repairSound;
    [SerializeField] float _repairSoundVolume = 1f;


    protected override bool CanAbsorb(Item item)
    {
        return item.GetType() == typeof(Title);
    }

    protected override void OnAbsorb(GameObject item)
    {
        Instantiate(_fieldPrefab, transform.position, transform.rotation);
        SFXManager.Instance.PlaySFXClip(_repairSound, transform.position, _repairSoundVolume);
        Destroy(item);
        Destroy(gameObject);
    }
}
