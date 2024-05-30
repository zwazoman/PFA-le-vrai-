using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_ShortcutWindmill : DialogueFlow
{
    public Df_Shop_ShortcutWindmill(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("Ce que cette #clef# ouvre ? Du diable si je le sa… oups, pardon patron. Enfin, je n’en ai aucune idée.");
        await _characters.Geoffrrus.Say("Achète là et tu trouveras bien, depuis le temps qu’elle est ici à rouiller dans mes stocks…");
        await _characters.Geoffrrus.Say($"Que dis tu de #{((SellingSpot)WorldObject).price} âmes# pour cela ? Enfin, comme si c’était négociable...");

        int resultat = await _characters.Narrator.Ask($"Voulez vous acheter cette #clef# pour #{((SellingSpot)WorldObject).price} âmes# ? (Vous en avez #{PlayerMain.Instance.Stats.Money}#)", new string[] { "J'achète !", "J'ai changé d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Aventureux hmm ? Et bien bonne chance à toi, tu me diras ce que tu as trouvé derrière la serrure !");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("Allons allons, ça se trouve cette clef fera de toi le prochain Crésus, je ne vais pas te l’offrir non plus…?");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Et bien je suppose que l’aventure attendra. ");
        }
    }
}
