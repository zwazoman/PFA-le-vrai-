using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_Shop_Seed : DialogueFlow
{
    public Df_Shop_Shop_Seed(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Bobbus, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("#Une graine# en plus pour votre labeur, que vous pouvez emportez de suite.");
        await _characters.Geoffrrus.Say($"Je vous en demande seulement quelques #poussi�res d'�mes {((SellingSpot)WorldObject).price}.#");

        int resultat = await _characters.Narrator.Ask($"Voulez vous cette #graine# pour #{((SellingSpot)WorldObject).price} poussi�res d'�mes.#?", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Tr�s bien, elle est � vous.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("Revenez lorsque vous pourrez vous l�offrir");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Cette �me attendra son tour ici dans ce cas.");
        }
    }
}
