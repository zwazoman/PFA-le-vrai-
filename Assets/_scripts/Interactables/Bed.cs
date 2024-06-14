using UnityEngine;
using UnityEngine.Rendering;

public class Bed : Interactable
{
    [SerializeField] private string DialogueScript;
    [SerializeField] private Volume _fondu;

    [SerializeField] Transform _HouseExit;
    protected override void Interaction()
    {
       
        _ = UiManager.Instance.PopupDialogue(DialogueScript, this); 
    }

    public void Sleep()
    {
        commencerFondu();
        TimeManager.Instance.SkipTo(6);
        
    }

    void teleportOutside()
    {
        PlayerMain.Instance.transform.position = _HouseExit.position;
        //PlayerMain.Instance.transform.rotation = _HouseExit.rotation;
        PlayerMain.Instance.Movement.SnapToGround();
        CameraBehaviour.Instance.TeleportToTargetPosition();
    }

    private void commencerFondu()
    {
        CameraBehaviour.Instance.enabled = false;
        PlayerMain.Instance.Movement.enabled = false;

        StartCoroutine(Nathan.InterpolateOverTime(0, 1, 0.5f, (float v) => _fondu.weight = v, Nathan.SmoothStep01, finirFondu));
    }

    void finirFondu()
    {
        //---- l'écran est tout noir ici ----

        teleportOutside();
        CameraBehaviour.Instance.enabled = true;
        PlayerMain.Instance.Movement.enabled = true;


        //-----------------------------------

        StartCoroutine(Nathan.InterpolateOverTime(1, 0, 0.5f, (float v) => _fondu.weight = v, Nathan.SmoothStep01, () => PlayerMain.Instance.Movement.enabled = true));
    }
}
