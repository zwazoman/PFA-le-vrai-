using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_HolyFlask : DialogueFlow
{
    public Df_Shop_HolyFlask(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Quentin, _characters.Noah);

        await _characters.Noah.Say("Une fiole contenant de l’eau du lac le plus pur du paradis… Utilisez à bonne escient pour purifier vos plantes, elle annulera toute traces de corruption.");
        await _characters.Noah.Say($"Pour une telle relique, j’en demande {((SellingSpot)WorldObject).price} âmes.");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'achète !", "J'ai changé d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Noah.Say("Prenez en soin, fermier, elle vaut plus cher que votre âme à elle seule.");
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
