using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_TitleDeed : DialogueFlow
{
    public Df_Shop_TitleDeed(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters,WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Bobbus);

        await _characters.Bobbus.Say("Avec ce parchemin, vous pourrez d�bloquer une nouvelle parcelle pour y planter des �mes et augmenter votre production.");
        await _characters.Bobbus.Say($"{((SellingSpot)WorldObject).price} �mes pour ton bon plaisir.");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat==0)   
        {
            if(((SellingSpot)WorldObject).price<=PlayerMain.Instance.Stats.Money)
            {
                await _characters.Bobbus.Say("Je ne sais pas si c�est une bonne id�e de vous donner plus de responsabilit�s, mais bon� Occupez vous en bien.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Bobbus.Say("Revenez me voir lorsque vous aurez travaill� et que vous pourrez vous payer cette parcelle !");
            }
        }
        else
        {
             await _characters.Bobbus.Say("Une autre fois peut-�tre...");         
        }
    }
}

