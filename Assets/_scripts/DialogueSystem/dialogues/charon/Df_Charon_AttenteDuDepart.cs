using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Df_Charon_AttenteDuDepart : DialogueFlow
{
    public Df_Charon_AttenteDuDepart(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    

    List<string> dialogue1 = new List<string>()
    {
        "A bient�t",
        "A la prochaine",
        "Nous nous reverrons, Bobbus",
        "Au plaisir",
        "Je reviendrais dans deux jours pour la prochaine livraison",
        "Tu tiens toujours le rythme ? Impressionant, le dernier avait d�j� craqu�",
        "J'esp�re que tu en as profit� pour explorer les environs... Allez, � la prochaine !",
        "Tu connais les graines ligma ? Non ? Bah, � bient�t.",
        "Et hop, encore une livraison.",
        "J'ai l'impression de passer ma mort � te livrer... Vous �tes tr�s fort pour vous entretuer.",
        "Ma femme m'a quitt� Bobbus.",
        "M�me chose, m�me heure dans deux jours.",
        "A la revoyure",
        "Ma vie n'est qu'un cycle monotone Bobbus. Je n'en peux plus. J'ai besoin d'un nouvel air. Termine vite ce jeu veux-tu ?"
    };

    

    public override async Task StartDialogue()
    { 
        _panel.InitDialogue(_characters.Bobbus, _characters.Charon);

        
        await _characters.Charon.Say(dialogue1[Random.Range(0,dialogue1.Count)]);
   

       
    }
}

