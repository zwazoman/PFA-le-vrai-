using CustomInspector.Editor;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{

    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private TMP_Text _titleText;

    [SerializeField] private Image _CharacterImage1;
    [SerializeField] private Image _CharacterImage2;
    [SerializeField] private DialogueCharacters characters;

    private Dictionary<DialogueCharacter, Image> characterDisplays = new();

    int characterTimeDelay = 50;

    //---
    DialogueFlow Flow;
    //public Dialogue d;

    //public int index = 0;
    [StringChoice]
    public string DialogueName;

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

    public void InitDialogue(DialogueCharacter character1, DialogueCharacter character2)
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
        foreach (DialogueCharacter character in characterDisplays.Keys)
        {
            SendCharacterToBackground(character);
        }
    }

    public void Start()
    {
        //object Flo =  new DialogueFlow(this,characters);
        //Flo = Convert.ChangeType(Flo, Type.GetType(DialogueName));
        DialogueFlow Flo = (DialogueFlow)Activator.CreateInstance(Type.GetType(DialogueName), this, characters);
        //Activator.CreateInstance(Type.GetType(DialogueName));
        Flo.StartDialogue();
    }
    //=================
    /*
        [CustomEditor(typeof(DialoguePanel))]
        [CanEditMultipleObjects]
        public class DialoguePanelEditor : Editor
        {

        public string[] options = new string[] { "DialogueTest_1", "Sphere", "Plane" };
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            serializedObject.Update();

            ((DialoguePanel)target).index = EditorGUILayout.Popup("Dialogue ", ((DialoguePanel)target).index, options);
            ((DialoguePanel)target).DialogueName = options[((DialoguePanel)target).index];
            //EditorGUILayout.PropertyField(lookAtPoint);
            serializedObject.ApplyModifiedProperties();

        }
    }*/

    //=================

}


