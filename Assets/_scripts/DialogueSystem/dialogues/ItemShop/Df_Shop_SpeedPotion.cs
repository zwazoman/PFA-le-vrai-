using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_SpeedPotion : DialogueFlow
{
    public Df_Shop_SpeedPotion(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Bobbus, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("Buvez ceci, et les vents eux m�me se porteront � vos pieds pour vous conf�rer #c�l�rit� et agilit�#.");
        await _characters.Geoffrrus.Say($"Je vous en demande seulement quelques #�mes# : #{((SellingSpot)WorldObject).price}#.");

        int resultat = await _characters.Narrator.Ask($"Voulez vous acheter cette #potion de vitesse# pour #{((SellingSpot)WorldObject).price} �mes# ? (Vous en avez #{PlayerMain.Instance.Stats.Money}#)", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Un bon choix, enfin.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("Ca ne se brade pas.");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Vous ne savez pas ce que vous ratez.");
        }
    }
}
