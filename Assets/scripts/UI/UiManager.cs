using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class UiManager : MonoBehaviour
{
    private static UiManager instance = null;
    public static UiManager Instance => instance;

    [SerializeField] DialoguePanel Dialogue_Panel;
    [SerializeField] GameplayPanel Gameplay_Panel;
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

    void HideEverything()
    {
        Dialogue_Panel.gameObject.SetActive(false);
        //Gameplay_Panel.gameObject.SetActive(false);
        //hide shop panel
    }

    //Gameplay
    public void ActivateGameplayPanel()
    {
        HideEverything();
        //Gameplay_Panel.gameObject.SetActive(true );
    }

    //Dialogue
    void ActivateDialoguePanel()
    {
        HideEverything() ;
        Dialogue_Panel.gameObject.SetActive(true);
    }

    public async Task PopupDialogue(string DialogueScript)
    {
        ActivateDialoguePanel();
        await Dialogue_Panel.StartDialogue(DialogueScript);
        ActivateGameplayPanel();
    }

    public async Task PopupSimpleString(string String)
    {
        ActivateDialoguePanel();
        await Dialogue_Panel.EasyWriteString(String);
        ActivateGameplayPanel();
    }

    //Shop
    public void ActivateShopPanel()
    {
        HideEverything();
        //show shop panel
    }

    
}
