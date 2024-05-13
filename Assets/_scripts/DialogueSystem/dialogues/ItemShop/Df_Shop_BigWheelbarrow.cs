using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_BigWheelbarrow : DialogueFlow
{
    public Df_Shop_BigWheelbarrow(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Quentin, _characters.Noah);

        await _characters.Noah.Say("La clef de la r�ussite, c�est aussi d�avoir un bon mat�riel. Cette brouette a justement servi fid�lement ton pr�d�cesseur, avant son� accident dirons nous ?");
        await _characters.Noah.Say("Enfin, elle te servira � transporter bien plus d��mes d�un coup.");
        await _characters.Noah.Say($"Je te le vend pour seulement {((SellingSpot)WorldObject).price} bitcoins! Quelle affaire!");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Noah.Say("Aaah� Voil� qui devrait t��pargner quelques aller-retour.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Noah.Say("Allons, je veux bien comprendre que tu manques de place, mais que tu manques �galement de sous ? Repasse plus tard.");
            }
        }
        else
        {
            await _characters.Noah.Say("Ah ? Bon, comme tu veux, apr�s tout �a n'est pas une question de taille�");
        }
    }
}

