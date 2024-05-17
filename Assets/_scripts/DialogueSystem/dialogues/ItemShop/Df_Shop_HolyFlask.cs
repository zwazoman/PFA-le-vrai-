using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_HolyFlask : DialogueFlow
{
    public Df_Shop_HolyFlask(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("Une fiole contenant de l’eau du lac le plus pur du paradis… Utilisez à bonne escient pour purifier vos plantes, elle annulera toute traces de corruption.");
        await _characters.Geoffrrus.Say($"Pour une telle relique, j’en demande {((SellingSpot)WorldObject).price} âmes.");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'achète !", "J'ai changé d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Prenez en soin, fermier, elle vaut plus cher que votre âme à elle seule.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("Une telle relique ne se donne pas à crédit.");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Elle restera à vous attendre.");
        }

    }

}
