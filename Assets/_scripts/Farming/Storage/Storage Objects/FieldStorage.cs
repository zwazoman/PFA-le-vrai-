using UnityEngine;

/// <summary>
/// g�re la r�cup�ration de graines dans le champ et indique au champ qu'il a re�u une graine
/// </summary>
public class FieldStorage : Storage
{
    [field : SerializeField]  
    public Field Field { get; set; }

    bool _sowed;

    private void Awake()
    {
        _sowed = false;
    }

    /// <summary>
    /// d�finit les types pouvant �tre absorb�s
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected override bool CanAbsorb(Item item)
    {
        return item.GetType() == typeof(Seed) || item.GetType() == typeof(Plant);
    }

    /// <summary>
    /// absorption des graines et des plantes par le champ
    /// </summary>
    /// <param name="item"></param>
    protected override void OnAbsorb(GameObject item)
    {
        if (_sowed) return;
        if (item.TryGetComponent<Seed>(out Seed seed))
        {
            Field.Sow(item);
            Destroy(item);
            _sowed = true;
        }
    }

    private void OnDestroy()
    {
        _sowed = false;
    }

    private void OnDisable()
    {
        _sowed = false;
    }
}
