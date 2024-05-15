using UnityEngine;

/// <summary>
/// orb lachée par les boutures d'âmes lors de la récolte. Héritage 
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
        //faire apparaître l'argent
        Destroy(gameObject);
    }
}
