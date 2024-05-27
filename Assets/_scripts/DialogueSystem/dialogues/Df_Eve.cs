using System.Threading.Tasks;
using UnityEngine;

public class Df_Eve : DialogueFlow
{
    public Df_Eve(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }
    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Eve, _characters.Bobbus);

        await _characters.Eve.Say("Blabla bla bla");
        int result = await _characters.Eve.Ask("Tu savais que Louis etais gay ?", new string[] { "Oui", "Non" });

        if (result == 0)
        {
            await _characters.Eve.Say("UwU");
        }
        else
        {
            await _characters.Eve.Say("Maintenant tu le sais");
        }
        
    }
}
