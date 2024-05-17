using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_WateringCan : DialogueFlow
{
    public Df_Shop_WateringCan(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Bobbus);

        await _characters.Bobbus.Say("Un meilleur arrosoir s’il n’en faut, tout fraichement sorti des fabriques de l’enfer !");
        await _characters.Bobbus.Say("Avec ça, tu ne devrais plus avoir de problèmes de transports d’eau, vu sa contenance.");
        await _characters.Bobbus.Say($"Je te le fais à {((SellingSpot)WorldObject).price} âmes.");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'achète !", "J'ai changé d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Bobbus.Say("Et voilà quelque chose que j’aime entendre, le doux tintement des âmes dans ma main !");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Bobbus.Say("Déjà à cours ? Repasse plus tard.");
            }
        }
        else
        {
            await _characters.Bobbus.Say("Bah, je suppose qu’il va rester ici à t’attendre…");
        }
    }
}
