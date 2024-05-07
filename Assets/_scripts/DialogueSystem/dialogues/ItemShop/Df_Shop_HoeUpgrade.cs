using System.Threading.Tasks;
using UnityEngine;


public class Df_Shop_HoeUpgrade : DialogueFlow
{
    public Df_Shop_HoeUpgrade(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Quentin, _characters.Noah);

        await _characters.Noah.Say("Cet objet est très utile.Il te permet de rendre ta houe plus éfficace.");
        await _characters.Noah.Say($"Je te le vend pour seulement {((SellingSpot)WorldObject).price} bitcoins! Quelle affaire!");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'achète !", "J'ai changé d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Noah.Say("ça c'est un client comme je les aime!");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Noah.Say("Retourne travailler,clochard");
            }
        }
        else
        {
            int resultat2 = await _characters.Narrator.Ask($"Bon ok, et si je te le fais à {(int)(((SellingSpot)WorldObject).price * 0.8f)} bitcoins ?", new string[] { "J'achète !", "Non, j'en veux vraiment pas" });
            if (resultat2 == 0)
            {
                if ((int)(((SellingSpot)WorldObject).price * 0.8f) <= PlayerMain.Instance.Stats.Money)
                {
                    ((SellingSpot)WorldObject).price = (int)(((SellingSpot)WorldObject).price * 0.8f);
                    await _characters.Noah.Say("ça c'est un client comme je les aime!");
                    WorldObject.SendMessage("SellItem");
                }
                else
                {
                    await _characters.Noah.Say("Je veux bien faire un geste, mais t'es vraiment trop pauvre. Retourne travailler,clochard");
                }
            }
            else
            {
                await _characters.Noah.Say("Une autre fois peut-être...");
            }
        }

    }

}
