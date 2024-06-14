using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_WestKey : DialogueFlow
{

    public Df_Shop_WestKey(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }
    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Bobbus, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("Voici la clef du portail de l'Ouest, qui m�ne vers le cimeti�re et au temple de l'Ange, Eve. ");
        await _characters.Geoffrrus.Say($"Alors, curieux ? Elle est � toi pour #{((SellingSpot)WorldObject).price} poussi�res d'�mes.#");

        int resultat = await _characters.Narrator.Ask($"Veux-tu acheter cette #clef# pour #{((SellingSpot)WorldObject).price} poussi�res d'�mes.#?", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        //EventSystem.current.SetSelectedGameObject(null);
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Passe le bonjour � Eve lorsque tu la verras !");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("AH. Ca risque d'�tre compliqu� vu l'�tat de tes finances.");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Je t'aurais cru plus aventureux");
        }
    }
}
