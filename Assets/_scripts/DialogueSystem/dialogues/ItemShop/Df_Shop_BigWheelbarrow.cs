using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_BigWheelbarrow : DialogueFlow
{
    public Df_Shop_BigWheelbarrow(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Bobbus);

        await _characters.Bobbus.Say("La clef de la réussite, c’est aussi d’avoir un bon matériel. Cette brouette a justement servi fidèlement ton prédécesseur, avant son… accident dirons nous ?");
        await _characters.Bobbus.Say($"Enfin, elle te servira à transporter bien plus d’âmes d’un coup, pour seulement {((SellingSpot)WorldObject).price} âmes.");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'achète !", "J'ai changé d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Bobbus.Say("Aaah… Voilà qui devrait t’épargner quelques aller-retour.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Bobbus.Say("Allons, je veux bien comprendre que tu manques de place, mais que tu manques également de sous ? Repasse plus tard.");
            }
        }
        else
        {
            await _characters.Bobbus.Say("Ah ? Bon, comme tu veux, après tout ça n'est pas une question de taille…");
        }
    }
}

