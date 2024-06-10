using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Df_Bed : DialogueFlow
{
    public Df_Bed(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    List<string> dialogueNarrator = new List<string>()

    { "Votre lit, moelleux et attrayant" ,
        "Votre lit ne vous a jamais paru si attirant",
        "Je suis ton lit. Viens dans mes bras, Bobbus" , 
        "Un beau lit moelleux" ,
        "Dormir ne vous a jamais fait autant envie" ,
        "Un brin de repos ne vous ferait sans doute pas de mal" ,
        "L'endroit parfait pour vous reposer.",
        "Vous n'avez plus qu'à poser la tête sur votre oreiller et vous endormir"
       


    };

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Narrator, _characters.Bobbus);

        await _characters.Narrator.Say(dialogueNarrator[Random.Range(0, dialogueNarrator.Count)]);

        int result = await _characters.Narrator.Ask("Souhaitez-vous dormir jusqu'au #matin# ?", new string[] { "Oui", "Non"});

        if (result == 0) 
        {
            WorldObject.SendMessage("La ferme s'endort.");
        }
        else
        {
           
        }
    }

}


