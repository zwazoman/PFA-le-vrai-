using System.Threading.Tasks;
using UnityEngine;


public class Df_Shop_Napalm : DialogueFlow
{
    public Df_Shop_Napalm(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("Une graine en plus pour votre labeur, que vous pouvez emportez de suite. Vous n’avez qu’à sélectionner un des trois types disponibles.");
        await _characters.Geoffrrus.Say($"Je vous en demande seulement quelques âmes, {((SellingSpot)WorldObject).price}.");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'achète !", "J'ai changé d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Hmmm… quelque part, savoir qu’un membre de votre espèce de primate violent est en possession d’un tel outil ne me rassure pas.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("Hors de question que je vous le laisse pour rien.");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Ca n’est pas plus mal, je doute que vous ayez la sagesse pour manier cela.");
        }
    }
}
