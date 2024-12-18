using UnityEngine;
using System.Threading.Tasks;

public class UiManager : MonoBehaviour
{
    private static UiManager instance = null;
    public static UiManager Instance => instance;

    [SerializeField] DialoguePanel Dialogue_Panel;
    [SerializeField] public GameplayPanel Gameplay_Panel;
    [SerializeField] PausePanel Pause_Panel;
    [SerializeField] GameObject Intro_Panel;
    [SerializeField] GameObject _firstButtonSelect;
    //[SerializeField] DialoguePanel Dialogue_Panel;


    public bool canPause = true;

    bool wasPaused = true;



    private void Start()
    {
        PlayerMain.Instance.InputManager.OnPause += OnPause;
        PlayerMain.Instance.WBInputManager.OnPause += OnPause;
    }

    private void OnPause()
    {
        if (Gameplay_Panel.gameObject.activeSelf)
        {
           // PlayerMain.Instance.Lock();

            ActivatePausePanel();
            //EventSystem.current.SetSelectedGameObject(_firstButtonSelect);
        }
        else
        {
            ActivateGameplayPanel();
            
        }

    }

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

    public void HideEverything()
    {
        if (!wasPaused && Pause_Panel.isActiveAndEnabled) TimeManager.Instance.resume();

        Intro_Panel.SetActive(false);
        Dialogue_Panel.gameObject.SetActive(false);
        Gameplay_Panel.gameObject.SetActive(false);
        Pause_Panel.gameObject.SetActive(false);
    }

    //Gameplay
    public void ActivateGameplayPanel()
    {
        HideEverything();

        //Input.SwitchCurrentActionMap("Player");

        Gameplay_Panel.gameObject.SetActive(true );
        Cursor.visible = false;
    }

    public void ActivateIntroPanel()
    {
        HideEverything();

        Intro_Panel.SetActive(true);
        Cursor.visible = false;
    }

    public void ActivatePausePanel()
    {
        if (!canPause) return;


        HideEverything();

        wasPaused = TimeManager.Instance.isPaused;
        if (!wasPaused ) TimeManager.Instance.pauseTime();

        Cursor.visible = true;
        Pause_Panel.gameObject.SetActive(true);



        //foreach (MonoBehaviour mb in PlayerMain.Instance.gameObject.GetComponents<MonoBehaviour>()) { mb.enabled = true; }
    }



    //Dialogue
    void ActivateDialoguePanel()
    {
        HideEverything() ;


        //Input.SwitchCurrentActionMap("UI");

        Cursor.visible = true;
        Dialogue_Panel.gameObject.SetActive(true);


    }

    public async Task PopupDialogue(string DialogueScript, MonoBehaviour worldObject)
    {
        //deactivate player
        foreach(MonoBehaviour mb in PlayerMain.Instance.gameObject.GetComponents<MonoBehaviour>()) { mb.enabled= false; }

        //pause the time 
        bool wasTimeAlreadyPaused = TimeManager.Instance.isPaused; //pour pas perturber si le temps �tait d�j� en pause,comme dans les magasins par exemple.


        if(!wasTimeAlreadyPaused) TimeManager.Instance.pauseTime();
        ActivateDialoguePanel();
        await Dialogue_Panel.StartDialogue(DialogueScript,worldObject);
        ActivateGameplayPanel();

        
        if (!wasTimeAlreadyPaused) TimeManager.Instance.resume();
        //reactivate player
        foreach (MonoBehaviour mb in PlayerMain.Instance.gameObject.GetComponents<MonoBehaviour>()) { mb.enabled = true; }
    }

    public async Task PopupSimpleString(string String) //fait apparaitre une ligne de dialogues sans afficher les personnages
    {
        //deactivate player
        PlayerMain.Instance.Lock();

        //pause the time 
        bool wasTimeAlreadyPaused = TimeManager.Instance.isPaused; //pour pas perturber si le temps �tait d�j� en pause,comme dans les magasins par exemple.
        if (!wasTimeAlreadyPaused) TimeManager.Instance.pauseTime();

        ActivateDialoguePanel();
        await Dialogue_Panel.EasyWriteString(String);
        ActivateGameplayPanel();

        //resume Time
        if (!wasTimeAlreadyPaused) TimeManager.Instance.resume();
        //reactivate player
        PlayerMain.Instance.UnLock();

    }



}
