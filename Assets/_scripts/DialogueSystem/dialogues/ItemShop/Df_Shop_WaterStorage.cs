using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_WateringCan : DialogueFlow
{
    public Df_Shop_WateringCan(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("-Un meilleur arrosoir- s’il n’en faut, tout fraichement sorti des fabriques de l’enfer !");
        await _characters.Geoffrrus.Say("Avec ça, tu ne devrais plus avoir de problèmes de transports d’eau, vu sa contenance.");
        await _characters.Geoffrrus.Say($"Je te le fais à -{((SellingSpot)WorldObject).price} âmes.-");

        int resultat = await _characters.Narrator.Ask($"Voulez vous acheter -l'amelioration de l'arrosoir- pour -{((SellingSpot)WorldObject).price} âmes.-?", new string[] { "J'achète !", "J'ai changé d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Et voilà quelque chose que j’aime entendre, le doux tintement des âmes dans ma main !");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("Déjà à cours ? Repasse plus tard.");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Bah, je suppose qu’il va rester ici à t’attendre…");
        }
    }
}
