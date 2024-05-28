using UnityEngine;

/// <summary>
/// orb lach�e par les boutures d'�mes lors de la r�colte. H�ritage 
/// </summary>
public class Orb : Breakable
{
    OrbCharon _tutorialScript;

    [field : SerializeField]
    public int OrbValue { get; private set; }

    protected override void Interaction()
    {
        base.Interaction();
        _tutorialScript.ActivateTutorial();
    }

    private void Awake()
    {
        _tutorialScript = GetComponent<OrbCharon>();
        Maxhp = 90;
        Jump();
    }


    protected override void Break()
    {
        PlayerMain.Instance.Stats.AddMoney(10);
        //faire appara�tre l'argent
        Destroy(gameObject);
    }
}
