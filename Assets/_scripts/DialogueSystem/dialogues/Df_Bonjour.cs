using System.Threading.Tasks;
using UnityEngine;

public class Df_Bonjour : DialogueFlow
{
    public Df_Bonjour(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters,WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Quentin, _characters.Noah);

        await _characters.Quentin.Say("OH PUTAIN CA MARCHE");
        await _characters.Noah.Say("NATHAN LE GOAT");
        await _characters.Narrator.Say("Bonjour c'est moi, gégé le narrateur");

        _characters.Quentin.SetEmotion(DialogueCharacter.Emotions.horny);
        await _characters.Quentin.Say("je suis si horny");
    }

}

