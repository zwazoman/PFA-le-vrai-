using System;
using System.Threading.Tasks;
using UnityEngine;


[CreateAssetMenu(fileName = "new Character", menuName = "Dialogue/Characters", order = 1)]
public class DialogueCharacters : ScriptableObject
{
    public DialogueCharacter Charon, Player, Narrator, Noah, Nestor;

    internal void initAllCharacters(DialogueFlow flow, DialoguePanel panel)
    {
        Charon.Init(flow, panel);
        Player.Init(flow, panel);
        Narrator.Init(flow, panel);
        Nestor.Init(flow, panel);
        Noah.Init(flow, panel);
    }
}


[Serializable]
public class DialogueCharacter
{
    [SerializeField] public string Name;
    [SerializeField] public Sprite Sprite;

    private DialogueFlow _Flow;
    private DialoguePanel _Panel;
    public void Init(DialogueFlow flow, DialoguePanel panel)
    {
        _Flow = flow;
        _Panel = panel;
    }

    public async Task Say(string text)
    {

        _Panel.SendAllCharactersToBackGround();
        _Panel.SetTalkingCharacter(this);

        await _Panel.Write(text);

        while (!Input.GetKeyUp(KeyCode.Space)) await Task.Yield();

    }

}


