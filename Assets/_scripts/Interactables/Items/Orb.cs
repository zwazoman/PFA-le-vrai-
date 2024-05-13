using UnityEngine;

/// <summary>
/// orb lach�e par les boutures d'�mes lors de la r�colte. H�ritage 
/// </summary>
public class Orb : Breakable
{
    [field : SerializeField]
    public int OrbValue { get; private set; }

    private void Awake()
    {
        maxhp = 10;
        Jump();
    }

    protected override void Break()
    {
        PlayerMain.Instance.Stats.AddMoney(10);
        //faire appara�tre l'argent
        Destroy(gameObject);
    }
}
