using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// la seule méthode à appeler de l'exterieur est : CreateDialogue()
/// </summary>



public class DialoguePanel : MonoBehaviour
{
    [Header("inputs")]
    public KeyCode skipKey = KeyCode.E;
    public DialogueInputManager _input;

    [Header("Simple Dialogue Box")]
    [SerializeField] private GameObject TextBox;
    [SerializeField] private TMP_Text _dialogueText;
    

    [Header("Character Display")]
    [SerializeField] private Image _CharacterImage1;
    [SerializeField] private Image _CharacterImage2;
    [SerializeField] private DialogueCharacters characters;
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private GameObject Arrow;
    private Dictionary<DialogueCharacter, Image> characterDisplays = new();

    [Header("Question Box")]
    [SerializeField] private GameObject OptionPanel;
    [SerializeField] private TMP_Text _QuestionDialogueText;
    [SerializeField] private Button ButtonPrefab;
    [SerializeField] private GameObject QuestionBox;


    int characterTimeDelay = 10;

    public void Start()
    {
        _input = PlayerMain.Instance.DialogueInput;
    }

    public async Task Write(string text)
    {
        QuestionBox.SetActive(false);
        TextBox.SetActive(true);
        Arrow.SetActive(false);

        _dialogueText.text = "";

        bool wasAlreadyHolding = Input.GetKey(skipKey) || (Gamepad.current != null && Gamepad.current.buttonSouth.isPressed);

        bool Tiret = false;
        foreach (char character in text)
        {
            //ecriture character par character
            if (character != '#')
            {
                _dialogueText.text += character;

                //skip avec la barre espace
                wasAlreadyHolding &= Input.GetKey(skipKey) || (Gamepad.current != null && Gamepad.current.buttonSouth.isPressed);
                if ((!(Input.GetKey(skipKey) || (Gamepad.current != null && Gamepad.current.buttonSouth.isPressed))) || wasAlreadyHolding) await Task.Delay(characterTimeDelay);
                //if (!DialogueInputManager._keyHold) await Task.Delay(characterTimeDelay);
            }
            else
            {
                Tiret = !Tiret;
                if(Tiret)
                {
                    _dialogueText.text += "<b><color=#ff0000ff>";
                }
                else
                {
                    _dialogueText.text += "</b></color>";

                }
            }


            
        }
        Arrow.SetActive(true);

        if (Input.GetKey(skipKey) || (Gamepad.current != null && Gamepad.current.buttonSouth.isPressed))
        {
            while (!(Input.GetKeyUp(skipKey) || (Gamepad.current != null && Gamepad.current.buttonSouth.wasReleasedThisFrame))) 
            { 
                await Task.Yield();
            } 
        } //t'inquiete


        //if (DialogueInputManager._keyHold) { while (!DialogueInputManager._keyUp) { await Task.Yield(); } }//t'inquiete
        //while (!(Input.GetKeyUp(skipKey) || Gamepad.current.buttonSouth.wasReleasedThisFrame)) { await Task.Yield(); print("while 2"); }
        //while (!DialogueInputManager._keyUp) await Task.Yield();
        await Task.Yield();
    }

    public async Task<int> WriteQuestion(string text, string[] options)
    {
        Cursor.visible = true;
        QuestionBox.SetActive(true);
        TextBox.SetActive(false);

        _QuestionDialogueText.text = "";
        int result = -1;

        //clear buttons
        foreach(Transform t in OptionPanel.transform)
        {
            Destroy(t.gameObject);
        }

        //popup buttons
        for (int i = 0; i < options.Length; i++)
        {


            OptionButton spawnedButton = Instantiate(ButtonPrefab.gameObject, OptionPanel.transform).GetComponent<OptionButton>();
            if (i == options.Length - 1)
            {
                EventSystem.current.SetSelectedGameObject(spawnedButton.gameObject);
            }
            int j = i;//t'inquiete
            spawnedButton.SetUp(options[i], () => { result = j; });
        }

        //write text
        bool Tiret = false;
        foreach (char character in text)
        {
            //ecriture character par character
            if (character != '#')
            {
                _QuestionDialogueText.text += character;

                //skip avec la barre espace
                //if (!DialogueInputManager._keyHold) await Task.Delay(characterTimeDelay);
            }
            else
            {
                Tiret = !Tiret;
                if(Tiret)
                {
                    _QuestionDialogueText.text += "<b><color=#ff0000ff>";
                }
                else
                {
                    _QuestionDialogueText.text += "</b></color>";

                }
            }

        }

        while(result == -1) await Task.Yield();

        Cursor.visible = false;
        return result;
        
    }


    public async Task EasyWriteString(string toWrite)
    {
        QuestionBox.SetActive(false);
        TextBox.SetActive(true);

        //InitDialogue(characters.Narrator, characters.Narrator);*
        HideCharacterSprites();
        await Write(toWrite);
        while (!(Input.GetKeyUp(skipKey) || (Gamepad.current != null && Gamepad.current.buttonSouth.wasReleasedThisFrame))) await Task.Yield();
        //while (!DialogueInputManager._keyUp) await Task.Yield();
        gameObject.SetActive(false);
    }

    void HideCharacterSprites()
    {
        _titleText.transform.parent.gameObject.SetActive(false);
        _CharacterImage1.enabled=false;
        _CharacterImage2.enabled=false;
    }
    void showCharacterSprites()
    {
        _titleText.transform.parent.gameObject.SetActive(true);
        _CharacterImage1.enabled = true;
        _CharacterImage2.enabled = true;
    }

    public void InitDialogue(DialogueCharacter character1, DialogueCharacter character2)
    {
        characterDisplays.Clear();
        characterDisplays.Add(character1, _CharacterImage1);
        characterDisplays.Add(character2, _CharacterImage2);

        _CharacterImage1.sprite = character1.Sprite;
        _CharacterImage2.sprite = character2.Sprite;
        showCharacterSprites();
    }

    public void UpdateCharacterSprite(DialogueCharacter character)
    {
        if(characterDisplays.ContainsKey(character))
        characterDisplays[character].sprite = character.Sprite;
    }

    public void SetTalkingCharacter(DialogueCharacter character)
    {
        if (character.Name != String.Empty) { _titleText.gameObject.transform.parent.gameObject.SetActive(true); _titleText.text = character.Name; } else { _titleText.gameObject.transform.parent.gameObject.SetActive(false); return; }

        characterDisplays[character].transform.localScale = Vector3.one * 1.35f;
        characterDisplays[character].color = Color.white;
    }

    public void SendCharacterToBackground(DialogueCharacter character)
    {
        if (!characterDisplays.ContainsKey(character) ) return;
        characterDisplays[character].transform.localScale = Vector3.one * 1.1f;
        characterDisplays[character].color = Color.white * 0.8f;
    }

    public void SendAllCharactersToBackGround()
    {
        foreach (DialogueCharacter character in characterDisplays.Keys)
        {
            SendCharacterToBackground(character);
        }
    }

    /// <summary>
    /// Appeler cette fonction pour faire parler deux personnages entre eux à partir d'un fichier de premierDialogueCharon contenant une classe enfant de DialogueFlow.
    /// Le parametre dialogueName correspond au nom du fichier de dialogueflow dans le dossier : Assets/scripts/DialogueSystem/dialogues
    /// </summary>
    /// <param name="DialogueName"></param>
    public async Task StartDialogue(string DialogueName,MonoBehaviour worldObject)
    {
        DialogueFlow Flo = (DialogueFlow)Activator.CreateInstance(Type.GetType(DialogueName), this, characters,worldObject);

        await Flo.StartDialogue();

        gameObject.SetActive(false);
    }

    //private void Start()
    //{
        //StartDialogue("Df_testQuestion",this);
    //}

}


