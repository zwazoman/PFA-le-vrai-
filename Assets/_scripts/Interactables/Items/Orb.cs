using UnityEngine;

/// <summary>
/// orb lach�e par les boutures d'�mes lors de la r�colte. H�ritage 
/// </summary>
public class Orb : Breakable
{
    OrbTuto _tutorialScript;

    [field : SerializeField]
    public int OrbValue { get; private set; }

    protected override void Interaction()
    {
        base.Interaction();
        _tutorialScript.ActivateTutorial();
    }

    public override void Awake()
    {
        base.Awake();
        _tutorialScript = GetComponent<OrbTuto>();
        //Jump();
    }

    public override void Break()
    {
        PlayerMain.Instance.Stats.AddMoney(10);
        Destroy(gameObject);
    }
}
