using System.Threading.Tasks;
using UnityEngine;



public class Df_Shop_FishingRod : DialogueFlow
{
    public Df_Shop_FishingRod(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Bobbus, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("Un peu de p�che pour se d�tendre apr�s s��tre occup� de toutes ces �mes ? Elle te permettra de t�essayer � la p�che sur le ponton qui longe ta ferme.");
        await _characters.Geoffrrus.Say($"Je te le vend pour seulement {((SellingSpot)WorldObject).price} bitcoins! Quelle affaire!");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Qui sait ce que tu vas trouver dans le Styx�");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("H� l�, je t�appr�cie, mais tout de m�me ! Reviens me voir lorsque tu auras quelques sous, et l� nous pourrons parler.");
            }
        }
        else
        {
                await _characters.Geoffrrus.Say("Les plaisirs de la p�che ne sont visiblement pas pour tout de suite� Au travail alors, ahahah !");
        }

    }
}
