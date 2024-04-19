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

    public async Task PopupDialogue(string DialogueScript, MonoBehaviour worldObject)
    {
        foreach(MonoBehaviour mb in PlayerMain.Instance.gameObject.GetComponents<MonoBehaviour>()) { mb.enabled= false; }

        ActivateDialoguePanel();
        await Dialogue_Panel.StartDialogue(DialogueScript,worldObject);
        ActivateGameplayPanel();

        foreach (MonoBehaviour mb in PlayerMain.Instance.gameObject.GetComponents<MonoBehaviour>()) { mb.enabled = true; }


    }

    public async Task PopupSimpleString(string String)
    {
        foreach (MonoBehaviour mb in PlayerMain.Instance.gameObject.GetComponents<MonoBehaviour>()) { mb.enabled = false; }
        ActivateDialoguePanel();
        await Dialogue_Panel.EasyWriteString(String);
        ActivateGameplayPanel();
        foreach (MonoBehaviour mb in PlayerMain.Instance.gameObject.GetComponents<MonoBehaviour>()) { mb.enabled = true; }
    }

    //Shop
    public void ActivateShopPanel()
    {
        HideEverything();
        //show shop panel
    }

    
}
