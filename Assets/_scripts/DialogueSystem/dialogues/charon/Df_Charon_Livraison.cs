using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Df_Charon_Livraison : DialogueFlow
{
    public Df_Charon_Livraison(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    List<string> dialogueBobbus = new List<string>()
    {
        "Déjà de retour ?",
        "Je l'attendais avec impatience",
        "Enfin !",
        "Toujours plus de graines",
        "Ah, pile à temps je commençais à en manquer...",
        "Déjà ? Mais combien de gens meurent par jour exactement ?",
        "Merci, Charon ",
        "J'en avais besoin",
        "Salut",
        "Hey",
        "Arg, ça n'en finit pas",
        "Je n'en vois pas le bout...",
        "Merci bien mon bon monsieur",
        "Je te le revaudrais"
    };

    List<string> dialogue1 = new List<string>()
    {
        "A bientôt",
        "A la prochaine",
        "Nous nous reverrons, Bobbus",
        "Au plaisir",
        "Je reviendrais dans deux jours pour la prochaine livraison",
        "Tu tiens toujours le rythme ? Impressionant, le dernier avait déjà craqué",
        "J'espère que tu en as profité pour explorer les environs... Allez, à la prochaine !",
        "Tu connais les graines ligma ? Non ? Bah, à bientôt.",
        "Et hop, encore une livraison.",
        "J'ai l'impression de passer ma mort à te livrer... Vous êtes très fort pour vous entretuer.",
        "Ma femme m'a quitté Bobbus.",
        "Même chose, même heure dans deux jours.",
        "A la revoyure",
        "Ma vie n'est qu'un cycle monotone Bobbus. Je n'en peux plus. J'ai besoin d'un nouvel air. Termine vite ce jeu veux-tu ?"
    };

    

    public override async Task StartDialogue()
    { 
        _panel.InitDialogue(_characters.Bobbus, _characters.Charon);

        
        await _characters.Bobbus.Say(dialogueBobbus[Random.Range(0,dialogueBobbus.Count)]);
        await _characters.Charon.Say(dialogue1[Random.Range(0,dialogue1.Count)]);
   

       
    }
}

