using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_PureWell : DialogueFlow
{
    public Df_Shop_PureWell(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("Un peu d’eau pure, que demander de plus ? En même temps, avec le nombre de cadavres qui sont tombés dedans");
        await _characters.Geoffrrus.Say("Je comprends que l’on puisse avoir envie de la purifier, ahaha ! Jette juste cette orbe dans le puit, et le lendemain les impuretés seront parties,");
        await _characters.Geoffrrus.Say($"et tu n’auras à débourser que {((SellingSpot)WorldObject).price} âmes pour ça.");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'achète !", "J'ai changé d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Il en faut peu pour être heureux, un peu d’eau fraîche et de verdure…");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("Hmmm, il semblerait que tu sois un peu à sec, niveau monnaie. Ahahaha, à sec. Tu as compris ?");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Non ? Bon, et bien tâche au moins de ne pas boire l’eau du puit, ca serait bête d’avoir à changer de fermier si tôt…");
        }
    }

}

