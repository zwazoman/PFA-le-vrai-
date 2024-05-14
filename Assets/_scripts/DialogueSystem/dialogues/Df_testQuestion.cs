using System.Threading.Tasks;
using UnityEngine;

public class Df_testQuestion : DialogueFlow
{
    public Df_testQuestion(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters,WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Quentin, _characters.Noah);

        await _characters.Quentin.Say("OH PUTAIN CA MARCHE");
        WorldObject.SendMessage("Message");
        await _characters.Noah.Say("NATHAN LE GOAT");



        int result =  await _characters.Narrator.Ask("comment tu vas toi?",new string[] {"Bien","pas bien","je bande"});
        //await _characters.Narrator.Say("Ta réponse est : "+result.ToString());
        if (result == 0) await _characters.Narrator.Say("Je suis content que tu ailles bien mon bebou au chocolat");
        else await _characters.Narrator.Say("Oh non qu'est-ce qui t'arrive ma creme glacée à la menthe gout fraise?? >_<");

        _characters.Quentin.SetEmotion(DialogueCharacter.Emotions.horny);
        await _characters.Quentin.Say("je bande");
        
    }

}

