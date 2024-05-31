using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static bool MillDialActivated = false;
    public static int WaitCount = 0;

    [SerializeField] string _waitDialogueScript;
    [SerializeField] string _millDialogueScript;


    private static TutorialManager instance = null;
    public static TutorialManager Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }


    public void ActivateTutorial()
    {
        if (MillDialActivated) return;
        _ = UiManager.Instance.PopupDialogue(_millDialogueScript, this);
        MillDialActivated = true;
    }

    public void ActivateWaitTutorial()
    {
        if (WaitCount > 3) return;
        WaitCount++;
        if (WaitCount == 3)
        {
            _ = UiManager.Instance.PopupDialogue(_millDialogueScript, this);
        }
    }
}
