using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class Df_Shop_WestKey : DialogueFlow
{

    public Df_Shop_WestKey(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }
    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Geoffrrus, _characters.Bobbus);

        await _characters.Geoffrrus.Say("Blablabla le dialogue de la clef #(Louis est gay)#");
        await _characters.Geoffrrus.Say($"Enfin, elle te servira � transporter bien plus d��mes d�un coup, pour seulement #{((SellingSpot)WorldObject).price} �mes.#");

        int resultat = await _characters.Narrator.Ask($"Voulez vous acheter cette #clef# pour #{((SellingSpot)WorldObject).price} �mes.#?", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        //EventSystem.current.SetSelectedGameObject(null);
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Aaah� Voil� qui devrait t��pargner quelques aller-retour.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("Allons, je veux bien comprendre que tu manques de place, mais que tu manques �galement de sous ? Repasse plus tard.");
            }
        }
        else
        {
            await _characters.Geoffrrus.Say("Ah ? Bon, comme tu veux, apr�s tout �a n'est pas une question de taille�");
        }
    }
}
