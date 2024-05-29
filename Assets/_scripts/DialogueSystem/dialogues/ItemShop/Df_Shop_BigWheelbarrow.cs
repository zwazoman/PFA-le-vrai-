using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class Df_Shop_BigWheelbarrow : DialogueFlow
{
    public Df_Shop_BigWheelbarrow(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    { 
        _panel.InitDialogue(_characters.Geoffrrus, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("La clef de la réussite, c’est aussi d’avoir un bon matériel. Cette -brouette- a justement servi fidèlement ton prédécesseur, avant son… accident dirons nous ?");
        await _characters.Geoffrrus.Say($"Enfin, elle te servira à transporter bien plus d’âmes d’un coup, pour seulement -{((SellingSpot)WorldObject).price} âmes.-");

        int resultat = await _characters.Narrator.Ask($"Voulez vous acheter la brouette pour  -{((SellingSpot)WorldObject).price} âmes.-?", new string[] { "J'achète !", "J'ai changé d'avis." });
        EventSystem.current.SetSelectedGameObject(null);
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Aaah… Voilà qui devrait t’épargner quelques aller-retour.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("Allons, je veux bien comprendre que tu manques de place, mais que tu manques également de sous ? Repasse plus tard.");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Ah ? Bon, comme tu veux, après tout ça n'est pas une question de taille…");
        }
    }
}

