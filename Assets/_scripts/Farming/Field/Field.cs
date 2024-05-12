using UnityEngine;

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
    int _hoeCount = 3;

    private void Awake()
    {
        IsEmpty = true;
        Sowable = false;
        _notSowableMesh = _mF.mesh;
        _hoeCount = 3;
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
            if(GetComponent<FieldStorage>()) Destroy(GetComponent<FieldStorage>());
        }
        _mF.mesh = Sowable ? _sowableMesh: _notSowableMesh;
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
    /// <summary>
    /// remet une plant retirée d'un champs via la pelle dans ce champ
    /// </summary>
    /// <param name="plant"></param>
    public void RePlant(GameObject plant)
    {
        if (Sowable && IsEmpty)
        {
            Destroy(GetComponent<FieldStorage>()); // detruit le storage
            plant.transform.position = transform.position + Vector3.up;
            //plant.transform.rotation = Quaternion.identity; // place la plante
            Destroy(plant.GetComponent<Item>());
            Destroy(plant.GetComponent<Rigidbody>()); // retire le rigidbody
            Destroy(plant.GetComponent<Plant>()); // retire Plant de type item
            plant.GetComponent<PlantMain>().PlantField = this; // définit ce champ comme étant le champ de la plante
            plant.GetComponent<PlantMain>().Corruption.UnFreezeCorruption();
            IsEmpty = false;
        }
    }
}