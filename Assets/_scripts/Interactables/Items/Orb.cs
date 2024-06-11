using UnityEngine;
using UnityEngine.VFX;

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
        if(_tutorialScript!=null) _tutorialScript.ActivateTutorial();
    }

    public override void Awake()
    {
        
        base.Awake();
        _tutorialScript = GetComponent<OrbTuto>();
        //Jump();
    }

    private void Start()
    {
        GetComponentInChildren<VisualEffect>().Play();
    }

    public override void Break()
    {
        PlayerMain.Instance.Stats.AddMoney(OrbValue);
        QuestManager.Instance.TryProgressQuest("BreakOrb", 1);
        base.Break();
    }
}
