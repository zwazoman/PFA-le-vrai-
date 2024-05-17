using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_WateringCan : DialogueFlow
{
    public Df_Shop_WateringCan(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Bobbus);

        await _characters.Bobbus.Say("Un meilleur arrosoir s�il n�en faut, tout fraichement sorti des fabriques de l�enfer !");
        await _characters.Bobbus.Say("Avec �a, tu ne devrais plus avoir de probl�mes de transports d�eau, vu sa contenance.");
        await _characters.Bobbus.Say($"Je te le fais � {((SellingSpot)WorldObject).price} �mes.");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Bobbus.Say("Et voil� quelque chose que j�aime entendre, le doux tintement des �mes dans ma main !");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Bobbus.Say("D�j� � cours ? Repasse plus tard.");
            }
        }
        else
        {
            await _characters.Bobbus.Say("Bah, je suppose qu�il va rester ici � t�attendre�");
        }
    }
}
