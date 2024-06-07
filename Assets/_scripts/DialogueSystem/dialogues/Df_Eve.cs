using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Df_Eve : DialogueFlow
{
    public Df_Eve(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    List<string> dialogueEve = new List<string>() 

    {
        "Ne me fais pas perdre mon temps si vous n'êtes pas encore prêt, mortel" ,
        "Vous n'avez pas des champs à bêcher ?",
        "Je sais que vous avez autres choses à faire que de m'ennuyer",
        "Votre âme ne va pas se racheter toute seule si vous restez ici",
        "Vous n'avez rien de mieux à faire de vos journées ?",
        "Je suis sûre d'avoir entendu la cloche de Charon. Vous devriez aller voir."
    };


    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Eve, _characters.Bobbus);

        await _characters.Bobbus.Say("Bonjour");

        int result = await _characters.Eve.Ask($"Alors, prêt à racheter ton âme ? Elle t'en coûtera {((Eve)WorldObject).price} poussières d'âmes", new string[] { "Oui", "Non" });

        if (result == 0 && PlayerMain.Instance.Stats.Money>=((Eve)WorldObject).price)
        {
            await _characters.Eve.Say("Tes efforts pour te racheter t'ont amenés à cet instant, mortel. Soit récompensé pour ton dévouement");
            WorldObject.SendMessage("OuvrirPorte");

        }
        else
         
        {

            await _characters.Eve.Say(dialogueEve[Random.Range(0,dialogueEve.Count)]);

        }
        
    }
}
