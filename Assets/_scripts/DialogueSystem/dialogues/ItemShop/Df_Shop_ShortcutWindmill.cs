using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_ShortcutWindmill : DialogueFlow
{
    public Df_Shop_ShortcutWindmill(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Quentin, _characters.Noah);

        await _characters.Noah.Say("Ce que cette clef ouvre ? Du diable si je le sa� oups, pardon patron. Enfin, je n�en ai aucune id�e.");
        await _characters.Noah.Say("Ach�te l� et tu trouveras bien, depuis le temps qu�elle est ici � rouiller dans mes stocks�");
        await _characters.Noah.Say($"Que dis tu de {((SellingSpot)WorldObject).price} �mes pour cela ? Enfin, comme si c��tait n�gociable� �mes pour �a.");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Noah.Say("Aventureux hmm ? Et bien bonne chance � toi, tu me diras ce que tu as trouv� derri�re la serrure !");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Noah.Say("Allons allons, �a se trouve cette clef fera de toi le prochain Cr�sus, je ne vais pas te l�offrir non plus�?");
            }
        }
        else
        {
            await _characters.Noah.Say("Et bien je suppose que l�aventure attendra. ");
        }
    }
}
