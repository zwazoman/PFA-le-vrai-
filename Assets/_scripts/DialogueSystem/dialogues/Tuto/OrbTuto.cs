using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTuto : MonoBehaviour
{
    public static bool Activated = false;
    [SerializeField] string _dialogueScript;

    private void Start()
    {
        if (Time.time <= 1)
        {
            Destroy(this);
        }
    }

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
