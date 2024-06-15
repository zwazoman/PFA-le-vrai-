using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Df_Bed : DialogueFlow
{
    public Df_Bed(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    List<string> dialogueNarrator = new List<string>()

    { "Ton lit, moelleux et attrayant" ,
        "Ton lit ne t'as jamais paru si attirant",
        "Je suis ton lit. Viens dans mes bras, Bobbus" ,
        "Un beau lit moelleux et musclé" ,
        "Dormir ne t'as jamais fait autant envie" ,
        "Un brin de repos ne te ferait sans doute pas de mal" ,
        "L'endroit parfait pour te reposer.",
        "Tu n'as plus qu'à poser la tête sur votre oreiller et t'endormir"
       


    };

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Bobbus, _characters.LeBigLit);

        await _characters.LeBigLit.Say(dialogueNarrator[Random.Range(0, dialogueNarrator.Count)]);

        int result = await _characters.LeBigLit.Ask("Veux-tu dormir avec moi jusqu'au matin, Bobbus ?", new string[] { "Oui", "Non"});

        if (result == 0) 
        {
            WorldObject.SendMessage("Sleep");
        }
        else
        {
           
        }
    }

}


