using CustomInspector;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(fileName = "new Character", menuName = "Dialogue/Characters", order = 1)]
public class DialogueCharacters : ScriptableObject
{
    public DialogueCharacter  Narrator, Geoffrrus, Bobbus,Charon,Eve; //penser à init les persos juste en dessous
    public void initAllCharacters(DialogueFlow flow, DialoguePanel panel)
    {
        Charon.Init(flow, panel);
        Narrator.Init(flow, panel);
        Bobbus.Init(flow, panel);
        Geoffrrus.Init(flow, panel);
        Eve.Init(flow, panel);
    }
}


[Serializable]
public class DialogueCharacter
{
    public string Name;
    public TMP_FontAsset Font;

    [HideInInspector]
    public Sprite Sprite;

    //[Dictionary]
    //public SerializableDictionary<Emotions, Sprite> EmotionSprites = new SerializableDictionary<Emotions, Sprite>();
    
    public enum Emotions
    {
        Normal,
        Happy,
        angry,
        hungry,
        blush,
        horny,
    }

    private DialogueFlow _Flow;
    private DialoguePanel _Panel;
    public void Init(DialogueFlow flow, DialoguePanel panel)
    {
        _Flow = flow;
        _Panel = panel;
        //SetEmotion(Emotions.Normal);
    }

    public async Task Say(string text)
    {

        _Panel.SendAllCharactersToBackGround();
        _Panel.SetTalkingCharacter(this);

        await _Panel.Write(text);

        while (!Input.GetKeyUp(_Panel.skipKey)) await Task.Yield();

    }

    public async Task<int> Ask(string Question, string[] options)
    {
        _Panel.SendAllCharactersToBackGround();
        _Panel.SetTalkingCharacter(this);

        
        int answer =  await _Panel.WriteQuestion(Question, options);

        return answer;
    }

    public void SetEmotion(Emotions newEmotion)
    {
        //Assert.IsTrue(EmotionSprites.ContainsKey(newEmotion),Name+ " n'a pas encore débloqué cette émotion.il ne peut pas être "+newEmotion.ToString() +". Connard. Va dessiner tes putains de sprites");
        //Sprite = EmotionSprites[newEmotion];
        //_Panel.UpdateCharacterSprite(this);
    }

}


