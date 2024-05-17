using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_Rain : DialogueFlow
{
    public Df_Shop_Rain(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Geoffrrus, _characters.Bobbus);

        await _characters.Bobbus.Say("Une petite ond�e b�nite peut �tre ? Avec cela, vous aurez l�occasion de convoquer une averse d�eau b�nite sur votre ferme et vos plantations.");
        await _characters.Bobbus.Say("Lisez juste la formule, et faite un dance de la pluie, et �a fonctionnera.");
        await _characters.Bobbus.Say($"Je l�ai obtenue d�un am�rindien, il y a quelques si�cles� C�est � vous pour {((SellingSpot)WorldObject).price} �mes.");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'ach�te !", "J'ai chang� d'avis." });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Bobbus.Say("La sagesse centenaire des anciens entre vos mains. Faites en bon usage.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Bobbus.Say("Allons, un tel tr�sor �a ne se brade pas !");
            }
        }
        else
        {
            await _characters.Bobbus.Say("Bon, ce parchemin n�ira pas loin de toute mani�re.");
        }
    }
}
