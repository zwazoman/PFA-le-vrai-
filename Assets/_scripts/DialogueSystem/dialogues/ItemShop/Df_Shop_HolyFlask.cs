using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_HolyFlask : DialogueFlow
{
    public Df_Shop_HolyFlask(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("Une fiole contenant de l�eau du lac le plus pur du paradis� Utilisez � bonne escient pour purifier vos plantes, elle annulera toute traces de corruption.");
        await _characters.Geoffrrus.Say($"Pour une telle relique, j�en demande {((SellingSpot)WorldObject).price} �mes.");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Prenez en soin, fermier, elle vaut plus cher que votre �me � elle seule.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("Une telle relique ne se donne pas � cr�dit.");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Elle restera � vous attendre.");
        }

    }

}
