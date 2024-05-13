using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_TitleDeed : DialogueFlow
{
    public Df_Shop_TitleDeed(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters,WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Quentin, _characters.Noah);

        await _characters.Noah.Say("Avec ce parchemin, vous pourrez débloquer une nouvelle parcelle pour y planter des âmes et augmenter votre production.");
        await _characters.Noah.Say($"Chaque titre vous coûtera un peu plus cher que le précédent. Ca vous fera {((SellingSpot)WorldObject).price} âmes.");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'achète !", "J'ai changé d'avis." });
        if (resultat==0)   
        {
            if(((SellingSpot)WorldObject).price<=PlayerMain.Instance.Stats.Money)
            {
                await _characters.Noah.Say("Je ne sais pas si c’est une bonne idée de vous donner plus de responsabilités, mais bon… Occupez vous en bien.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Noah.Say("Revenez me voir lorsque vous aurez travaillé et que vous pourrez vous payer cette parcelle !");
            }
        }
        else
        {
             await _characters.Noah.Say("Une autre fois peut-être...");         
        }
    }
}

