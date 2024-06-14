using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_TitleDeed : DialogueFlow
{
    public Df_Shop_TitleDeed(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters,WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Bobbus, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("Avec ce parchemin, vous pourrez d�bloquer une #nouvelle parcelle de champ# pour y planter des �mes# et augmenter votre production.");
        await _characters.Geoffrrus.Say($"#{((SellingSpot)WorldObject).price}poussi�res d'�mes# pour ce titre");

        int resultat = await _characters.Narrator.Ask($"Voulez vous augmenter la taille de votre champs en achetant ce #titre de propri�t�# pour #{((SellingSpot)WorldObject).price} �mes# ? (Vous en avez #{PlayerMain.Instance.Stats.Money}#)", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat==0)   
        {
            if(((SellingSpot)WorldObject).price<=PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Je ne sais pas si c�est une bonne id�e de vous donner plus de responsabilit�s, mais bon� Occupez vous en bien.");
                WorldObject.SendMessage("SellItem");
                //((SellingSpot)WorldObject).price += 5;
            }
            else
            {
                await _characters.Geoffrrus.Say("");
            }
        }
        else
        {
             await _characters.Geoffrrus.Say("Une autre fois peut-�tre...");         
        }
    }
}

