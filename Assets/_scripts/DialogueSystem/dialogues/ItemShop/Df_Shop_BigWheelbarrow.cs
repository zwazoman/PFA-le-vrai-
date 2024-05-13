using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_BigWheelbarrow : DialogueFlow
{
    public Df_Shop_BigWheelbarrow(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Quentin, _characters.Noah);

        await _characters.Noah.Say("La clef de la réussite, c’est aussi d’avoir un bon matériel. Cette brouette a justement servi fidèlement ton prédécesseur, avant son… accident dirons nous ?");
        await _characters.Noah.Say("Enfin, elle te servira à transporter bien plus d’âmes d’un coup.");
        await _characters.Noah.Say($"Je te le vend pour seulement {((SellingSpot)WorldObject).price} bitcoins! Quelle affaire!");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'achète !", "J'ai changé d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Noah.Say("Aaah… Voilà qui devrait t’épargner quelques aller-retour.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Noah.Say("Allons, je veux bien comprendre que tu manques de place, mais que tu manques également de sous ? Repasse plus tard.");
            }
        }
        else
        {
            await _characters.Noah.Say("Ah ? Bon, comme tu veux, après tout ça n'est pas une question de taille…");
        }
    }
}

