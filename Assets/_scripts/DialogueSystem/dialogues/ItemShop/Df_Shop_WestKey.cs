using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_WestKey : DialogueFlow
{

    public Df_Shop_WestKey(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }
    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Bobbus, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("Voici la clef du portail de l'Ouest, qui mène vers le cimetière et au temple de l'Ange, Eve. ");
        await _characters.Geoffrrus.Say($"Alors, curieux ? Elle est à toi pour #{((SellingSpot)WorldObject).price} poussières d'âmes.#");

        int resultat = await _characters.Narrator.Ask($"Veux-tu acheter cette #clef# pour #{((SellingSpot)WorldObject).price} poussières d'âmes.#?", new string[] { "J'achète !", "J'ai changé d'avis." });
        //EventSystem.current.SetSelectedGameObject(null);
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Passe le bonjour à Eve lorsque tu la verras !");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("AH. Ca risque d'être compliqué vu l'état de tes finances.");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Je t'aurais cru plus aventureux");
        }
    }
}
