using System.Threading.Tasks;
using UnityEngine;

public class Df_Bed : DialogueFlow
{
    public Df_Bed(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Narrator, _characters.Bobbus);

        await _characters.Narrator.Say("Ceci est un lit");
        int result = await _characters.Narrator.Ask("Souhaitez vous dormir ?", new string[] { "Oui", "Non"});

        if (result == 0) 
        {
            WorldObject.SendMessage("Sleep");
        }
        else
        {
           
        }
    }
}
