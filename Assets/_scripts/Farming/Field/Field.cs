using UnityEngine;
using UnityEngine.VFX;

/// <summary>
/// gère le champ et la plante de graines
/// </summary>
public class Field : MonoBehaviour
{
    public bool Sowable { get; set; }
    public bool IsEmpty {get;set;}
    private GameObject _plant;
    [SerializeField] MeshFilter _mF;
    [SerializeField] Mesh _sowableMesh;
    [SerializeField] Mesh _notSowableMesh;
    [SerializeField] Collider _destroyCollider;
    int _hoeCount = 3;

    [SerializeField] VisualEffect hitVFX;

    [SerializeField] bool SowOnStart = false;

    private void Awake()
    {
        IsEmpty = true;
        Sowable = false;
        _notSowableMesh = _mF.mesh;
        _hoeCount = 3;
    }

    private void Start()
    {
        if (SowOnStart)
        {
            Sowable = true;
            if (Sowable)
            {
                FieldStorage storage = gameObject.AddComponent<FieldStorage>();
                storage.Field = this;
            }

            _mF.mesh = Sowable ? _sowableMesh : _notSowableMesh;
            _destroyCollider.enabled = Sowable;
        }
    }


    /// <summary>
    /// change le mesh du champ, le rend apte a la plantation lors d'un coup de bêche
    /// </summary>
    public void Plow()
    {
        
        if (!IsEmpty ) return;  
        
        print("try plow");
        _hoeCount--;
        
        Sowable = _hoeCount<=0;
        if (Sowable)
        {
            FieldStorage storage = gameObject.AddComponent<FieldStorage>();
            storage.Field = this;
        }
        else
        {
            Destroy( Instantiate(hitVFX, transform.position, Quaternion.identity),5);

            if(GetComponent<FieldStorage>()) Destroy(GetComponent<FieldStorage>());
        }
        _mF.mesh = Sowable ? _sowableMesh: _notSowableMesh;
        _destroyCollider.enabled = Sowable;
    }

    /// <summary>
    /// fait apparaitre une plante et détruit le stockage du champ si le champe st ^pte a la plantation.
    /// </summary>
    /// <param name="seed"></param>
    public void Sow(GameObject seed)
    {
        print("try Sow");
        if (Sowable && IsEmpty)
        {
            print("sow");
            _plant = seed.GetComponent<Seed>().Plant;
            Destroy(GetComponent<FieldStorage>());
            GameObject plant = Instantiate(_plant, transform.position + Vector3.up* 0.42f, Quaternion.identity);
            plant.GetComponent<PlantMain>().PlantField = this;
            IsEmpty = false;
            _hoeCount = 4;
        }
    }
}