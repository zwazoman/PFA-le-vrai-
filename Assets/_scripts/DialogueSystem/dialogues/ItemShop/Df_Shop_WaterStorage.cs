using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_WateringCan : DialogueFlow
{
    public Df_Shop_WateringCan(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("-Un meilleur arrosoir- s�il n�en faut, tout fraichement sorti des fabriques de l�enfer !");
        await _characters.Geoffrrus.Say("Avec �a, tu ne devrais plus avoir de probl�mes de transports d�eau, vu sa contenance.");
        await _characters.Geoffrrus.Say($"Je te le fais � -{((SellingSpot)WorldObject).price} �mes.-");

        int resultat = await _characters.Narrator.Ask($"Voulez vous acheter -l'amelioration de l'arrosoir- pour -{((SellingSpot)WorldObject).price} �mes.-?", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Et voil� quelque chose que j�aime entendre, le doux tintement des �mes dans ma main !");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("D�j� � cours ? Repasse plus tard.");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Bah, je suppose qu�il va rester ici � t�attendre�");
        }
    }
}
