using System.Threading.Tasks;
using UnityEngine;



public class Df_Shop_FishingRod : DialogueFlow
{
    public Df_Shop_FishingRod(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Bobbus, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("Un peu de pêche pour se détendre après s’être occupé de toutes ces âmes ? Elle te permettra de t’essayer à la pêche sur le ponton qui longe ta ferme.");
        await _characters.Geoffrrus.Say($"Je te le vend pour seulement {((SellingSpot)WorldObject).price} bitcoins! Quelle affaire!");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'achète !", "J'ai changé d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Qui sait ce que tu vas trouver dans le Styx…");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("Hé là, je t’apprécie, mais tout de même ! Reviens me voir lorsque tu auras quelques sous, et là nous pourrons parler.");
            }
        }
        else
        {
                await _characters.Geoffrrus.Say("Les plaisirs de la pêche ne sont visiblement pas pour tout de suite… Au travail alors, ahahah !");
        }

    }
}
