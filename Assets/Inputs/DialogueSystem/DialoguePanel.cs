using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{

    [SerializeField] private DialogueFlow _dialogue;
    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private TMP_Text _titleText;

    [SerializeField] private Image _CharacterImage1;
    [SerializeField] private Image _CharacterImage2;

    private Dictionary<DialogueCharacter,Image> characterDisplays;

    const int characterTimeDelay = 50;

    //---
    DialogueFlow dialogue;

    public async Task Write(string text) 
    {
        _dialogueText.text = "";
        
        foreach ( char character in text) 
        {
            _dialogueText.text += character;
            if(!Input.GetKeyDown(KeyCode.Space) ) await Task.Delay(characterTimeDelay);
        }
        if (Input.GetKeyDown(KeyCode.Space)) await Task.Yield(); //t'inquiete

    }

    public void InitDialogue(DialogueCharacter character1,DialogueCharacter character2)
    {
        characterDisplays.Add(character1, _CharacterImage1);
        _CharacterImage1.sprite = character1.Sprite;

        characterDisplays.Add(character2, _CharacterImage2);
        _CharacterImage2.sprite = character2.Sprite;

    }

    public void SetTalkingCharacter(DialogueCharacter character)
    {
        _titleText.text = character.Name;
        characterDisplays[character].transform.localScale = Vector3.one * 1.1f;
        characterDisplays[character].color = Color.white;
    }

    public void SendCharacterToBackground(DialogueCharacter character)
    {
        characterDisplays[character].transform.localScale = Vector3.one * 0.8f;
        characterDisplays[character].color = Color.white * 0.8f;
    }

    public void SendAllCharactersToBackGround()
    {
        foreach ( DialogueCharacter character in characterDisplays.Keys ) 
        {
            SendCharacterToBackground(character);    
        }
    }

    public void Start()
    {
         dialogue.StartDialogue();
    }
}
