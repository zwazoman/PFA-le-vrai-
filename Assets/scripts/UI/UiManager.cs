using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    private static UiManager instance = null;
    public static UiManager Instance => instance;

    [SerializeField] DialoguePanel Dialogue_Panel;
    //[SerializeField] DialoguePanel Dialogue_Panel;

    private void Awake()
    {
        //Singleton
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

    //Gameplay
    public void ActivateGameplayPanel()
    {

    }

    //Dialogue
    void ActivateDialoguePanel()
    {

    }

    public void PopupDialogue(string DialogueScript)
    {
        ActivateDialoguePanel();

    }

    //Shop
    public void ActivateShopPanel()
    {

    }

    
}
