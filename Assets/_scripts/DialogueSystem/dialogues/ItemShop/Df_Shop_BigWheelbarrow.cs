using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_BigWheelbarrow : DialogueFlow
{
    public Df_Shop_BigWheelbarrow(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Bobbus);

        await _characters.Bobbus.Say("La clef de la r�ussite, c�est aussi d�avoir un bon mat�riel. Cette brouette a justement servi fid�lement ton pr�d�cesseur, avant son� accident dirons nous ?");
        await _characters.Bobbus.Say($"Enfin, elle te servira � transporter bien plus d��mes d�un coup, pour seulement {((SellingSpot)WorldObject).price} �mes.");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Bobbus.Say("Aaah� Voil� qui devrait t��pargner quelques aller-retour.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Bobbus.Say("Allons, je veux bien comprendre que tu manques de place, mais que tu manques �galement de sous ? Repasse plus tard.");
            }
        }
        else
        {
            await _characters.Bobbus.Say("Ah ? Bon, comme tu veux, apr�s tout �a n'est pas une question de taille�");
        }
    }
}

