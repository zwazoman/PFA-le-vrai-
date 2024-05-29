using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_Shop_Seed : DialogueFlow
{
    public Df_Shop_Shop_Seed(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Geoffrrus, _characters.Bobbus);

        await _characters.Geoffrrus.Say("#Une graine# en plus pour votre labeur, que vous pouvez emportez de suite. Vous n�avez qu�� s�lectionner un des trois types disponibles.");
        await _characters.Geoffrrus.Say($"Je vous en demande seulement quelques #�mes, {((SellingSpot)WorldObject).price}.#");

        int resultat = await _characters.Narrator.Ask($"Voulez vous cette #graine# pour #{((SellingSpot)WorldObject).price} �mes.#?", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Bien. Prenez cette �me, et faite votre devoir, fermier.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("Une telle faveur n�est pas sans co�t. Revenez lorsque vous pourrez vous l�offrir");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Tr�s bien.");
        }
    }
}
