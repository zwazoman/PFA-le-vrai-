using UnityEngine;

/// <summary>
/// orb lachée par les boutures d'âmes lors de la récolte. Héritage 
/// </summary>
public class Orb : Breakable
{
    [field : SerializeField]
    public int OrbValue { get; private set; }

    protected override void Interaction()
    {
        base.Interaction();
    }

    public override void Awake()
    {
        base.Awake();
        //Jump();
    }

    public override void Break()
    {
        PlayerMain.Instance.Stats.AddMoney(OrbValue);
        QuestManager.Instance.TryProgressQuest("BreakOrb", 1);
        base.Break();
    }
}
