using UnityEngine;

/// <summary>
/// orb lachée par les boutures d'âmes lors de la récolte. Héritage 
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

    private void Awake()
    {
        _tutorialScript = GetComponent<OrbTuto>();
        Maxhp = 90;
        Jump();
    }

    protected override void Break()
    {
        PlayerMain.Instance.Stats.AddMoney(10);
        //faire apparaître l'argent
        Destroy(gameObject);
    }
}
