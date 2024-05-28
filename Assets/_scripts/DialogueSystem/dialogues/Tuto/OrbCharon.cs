using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCharon : MonoBehaviour
{
    public static bool Activated = false;
    [SerializeField] string _dialogueScript;

    public void ActivateTutorial()
    {
        if (!Activated)
        {
            _ = UiManager.Instance.PopupDialogue(_dialogueScript, this);
            Activated = true;
        }
        Destroy(this);
    }
}
