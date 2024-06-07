using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Df_Eve : DialogueFlow
{
    public Df_Eve(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    List<string> dialogueEve = new List<string>() 

    {
        "Ne me fais pas perdre mon temps si vous n'�tes pas encore pr�t, mortel" ,
        "Vous n'avez pas des champs � b�cher ?",
        "Je sais que vous avez autres choses � faire que de m'ennuyer",
        "Votre �me ne va pas se racheter toute seule si vous restez ici",
        "Vous n'avez rien de mieux � faire de vos journ�es ?",
        "Je suis s�re d'avoir entendu la cloche de Charon. Vous devriez aller voir."
    };


    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Eve, _characters.Bobbus);

        await _characters.Bobbus.Say("Bonjour");

        int result = await _characters.Eve.Ask($"Alors, pr�t � racheter ton �me ? Elle t'en co�tera {((Eve)WorldObject).price} poussi�res d'�mes", new string[] { "Oui", "Non" });

        if (result == 0 && PlayerMain.Instance.Stats.Money>=((Eve)WorldObject).price)
        {
            await _characters.Eve.Say("Tes efforts pour te racheter t'ont amen�s � cet instant, mortel. Soit r�compens� pour ton d�vouement");
            WorldObject.SendMessage("OuvrirPorte");

        }
        else
         
        {

            await _characters.Eve.Say(dialogueEve[Random.Range(0,dialogueEve.Count)]);

        }
        
    }
}
