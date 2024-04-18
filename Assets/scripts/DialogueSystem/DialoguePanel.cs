using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

/// <summary>
/// la seule méthode à appeler de l'exterieur est : CreateDialogue()
/// </summary>



public class DialoguePanel : MonoBehaviour
{

    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private TMP_Text _titleText;

    [SerializeField] private Image _CharacterImage1;
    [SerializeField] private Image _CharacterImage2;
    [SerializeField] private DialogueCharacters characters;

    private Dictionary<DialogueCharacter, Image> characterDisplays = new();

    int characterTimeDelay = 50;

    public async Task Write(string text)
    {
        _dialogueText.text = "";

        foreach (char character in text)
        {
            _dialogueText.text += character;
            if (!Input.GetKey(KeyCode.Space)) await Task.Delay(characterTimeDelay);
        }
        if (Input.GetKey(KeyCode.Space)) while (!Input.GetKeyUp(KeyCode.Space)) await Task.Yield(); //t'inquiete
        await Task.Yield();
    }

    public async Task<int> WriteQuestion(string text, string[] options)
    {
        _dialogueText.text = "";

        foreach (char character in text)
        {
            _dialogueText.text += character;
            if (!Input.GetKey(KeyCode.Space)) await Task.Delay(characterTimeDelay);
        }
        if (Input.GetKey(KeyCode.Space)) while (!Input.GetKeyUp(KeyCode.Space)) await Task.Yield(); //t'inquiete
        await Task.Yield();



        return 0;
    }

    public async Task EasyWriteString(string toWrite)
    {
        //InitDialogue(characters.Narrator, characters.Narrator);*
        HideCharacterSprites();
        await Write(toWrite);
        while (!Input.GetKeyUp(KeyCode.Space)) await Task.Yield();
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

        characterDisplays[character].transform.localScale = Vector3.one * 1.1f;
        characterDisplays[character].color = Color.white;
    }

    public void SendCharacterToBackground(DialogueCharacter character)
    {
        if (!characterDisplays.ContainsKey(character) ) return;
        characterDisplays[character].transform.localScale = Vector3.one * 0.8f;
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
    /// Appeler cette fonction pour faire parler deux personnages entre eux à partir d'un fichier de dialogue contenant une classe enfant de DialogueFlow.
    /// Le parametre dialogueName correspond au nom du fichier de dialogueflow dans le dossier : Assets/scripts/DialogueSystem/dialogues
    /// </summary>
    /// <param name="DialogueName"></param>
    public async Task StartDialogue(string DialogueName)
    {
        DialogueFlow Flo = (DialogueFlow)Activator.CreateInstance(Type.GetType(DialogueName), this, characters);
        await Flo.StartDialogue();
    }

    private void Start()
    {
        //StartDialogue("Df_Bonjour");
    }
}


