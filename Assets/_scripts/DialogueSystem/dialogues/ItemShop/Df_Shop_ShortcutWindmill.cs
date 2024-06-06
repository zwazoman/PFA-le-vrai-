using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_ShortcutWindmill : DialogueFlow
{
    public Df_Shop_ShortcutWindmill(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Geoffrrus, _characters.Bobbus);

        await _characters.Geoffrrus.Say("Ce que cette #clef# ouvre ? Je n�en ai aucune id�e.");
        await _characters.Geoffrrus.Say("Ach�te l� et tu trouveras bien, depuis le temps qu�elle est ici � rouiller dans mes stocks�");
        await _characters.Geoffrrus.Say($"Que dis tu de #{((SellingSpot)WorldObject).price} poussi�res d'�mes# pour cela ?");

        int resultat = await _characters.Narrator.Ask($"Voulez vous acheter cette #clef# pour #{((SellingSpot)WorldObject).price} poussi�res d'�mes# ? (Vous en avez #{PlayerMain.Instance.Stats.Money}#)", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Aventureux hmm ? Et bien bonne chance � toi, tu me diras ce que tu as trouv� derri�re la serrure !");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("Allons allons, �a se trouve cette clef fera de toi le prochain Cr�sus, je ne vais pas te l�offrir non plus�?");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Et bien je suppose que l�aventure attendra. ");
        }
    }
}
