using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Df_Charon_AttenteDuDepart : DialogueFlow
{
    public Df_Charon_AttenteDuDepart(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    

    List<string> dialogue1 = new List<string>()
    {
        "Plus rien pour toi aujourd'hui.",
        "Tu viens me faire causette ?",
        "Hmmm, laisse moi voir... Non plus rien.",
        "Pas de graines en plus.",
        "Je reviendrais dans deux jours pour la prochaine livraison.",
        "Encore ? Occupe toi déjà de ce que je viens de te donner.",
        "Tu m'en demandes trop, repasses la prochaine fois.",
        "Nop, plus rien pour aujourd'hui.",
        "Pas plus de graines.",
        "Laisse moi me reposer un moment veux-tu ?",
        "Repasse plus tard.",
        "On vient voir papy Charon ? Comme c'est gentil !",
        "Une autre fois, Bobbus. Je n'ai plus rien pour aujourd'hui",
        "Zzzz... Hein ? Oh pardon je me suis endormi..."
    };

    

    public override async Task StartDialogue()
    { 
        _panel.InitDialogue(_characters.Bobbus, _characters.Charon);

        
        await _characters.Charon.Say(dialogue1[Random.Range(0,dialogue1.Count)]);
   

       
    }
}

