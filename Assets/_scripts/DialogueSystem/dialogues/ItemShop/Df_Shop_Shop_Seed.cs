using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_Shop_Seed : DialogueFlow
{
    public Df_Shop_Shop_Seed(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Bobbus);

        await _characters.Bobbus.Say("Une graine en plus pour votre labeur, que vous pouvez emportez de suite. Vous n’avez qu’à sélectionner un des trois types disponibles.");
        await _characters.Bobbus.Say($"Je vous en demande seulement quelques âmes, {((SellingSpot)WorldObject).price}.");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'achète !", "J'ai changé d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Bobbus.Say("Bien. Prenez cette âme, et faite votre devoir, fermier.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Bobbus.Say("Une telle faveur n’est pas sans coût. Revenez lorsque vous pourrez vous l’offrir");
            }
        }
        else
        {
            await _characters.Bobbus.Say("Très bien.");
        }
    }
}
