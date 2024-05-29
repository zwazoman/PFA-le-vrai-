using UnityEngine;
using UnityEngine.Rendering;

public class Bed : Interactable
{
    [SerializeField] private string DialogueScript;
    [SerializeField] private Volume _fondu;
    protected override void Interaction()
    {
        print("OwO");
       
        _ = UiManager.Instance.PopupDialogue(DialogueScript, this); 
        print("XwX");
    }

    public void Sleep()
    {
        commencerFondu();
        if (TimeManager.Instance.Hour < 6 || TimeManager.Instance.Hour > 18)
        {
            TimeManager.Instance.SkipTo(6);
            Debug.Log($"Hour: {TimeManager.Instance.Hour}");
        }
        else if (TimeManager.Instance.Hour > 6 && TimeManager.Instance.Hour < 18)
        {
            TimeManager.Instance.SkipTo(18);
            Debug.Log($"Hour: {TimeManager.Instance.Hour}");
        }
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

        CameraBehaviour.Instance.enabled = true;
        PlayerMain.Instance.Movement.enabled = true;


        //-----------------------------------

        StartCoroutine(Nathan.InterpolateOverTime(1, 0, 0.5f, (float v) => _fondu.weight = v, Nathan.SmoothStep01, () => PlayerMain.Instance.Movement.enabled = true));
    }
}
