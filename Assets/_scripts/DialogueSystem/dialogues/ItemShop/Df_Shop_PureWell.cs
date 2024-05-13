using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_PureWell : DialogueFlow
{
    public Df_Shop_PureWell(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Quentin, _characters.Noah);

        await _characters.Noah.Say("Un peu d�eau pure, que demander de plus ? En m�me temps, avec le nombre de cadavres qui sont tomb�s dedans");
        await _characters.Noah.Say("Je comprends que l�on puisse avoir envie de la purifier, ahaha ! Jette juste cette orbe dans le puit, et le lendemain les impuret�s seront parties.");
        await _characters.Noah.Say($"Je te le vend pour seulement {((SellingSpot)WorldObject).price} bitcoins! Quelle affaire!");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Noah.Say("Il en faut peu pour �tre heureux, un peu d�eau fra�che et de verdure�");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Noah.Say("Hmmm, il semblerait que tu sois un peu � sec, niveau monnaie. Ahahaha, � sec. Tu as compris ?");
            }
        }
        else
        {
            await _characters.Noah.Say("Non ? Bon, et bien t�che au moins de ne pas boire l�eau du puit, ca serait b�te d�avoir � changer de fermier si t�t�");
        }
    }

}

