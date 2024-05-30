using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_PermBestDelivery : DialogueFlow
{
    public Df_Shop_PermBestDelivery(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Geoffrrus);

        await _characters.Geoffrrus.Say("Aaah, je me demandais quand tu allais venir la prendre, celle-ci. Il te suffit de l�activer, et tu auras #une livraison d��mes plus importante# de la part de Charon.");
        await _characters.Geoffrrus.Say($"Une vrai petite merveille que je te vend pour #{((SellingSpot)WorldObject).price} �mes#.");

        int resultat = await _characters.Narrator.Ask($"Voulez vous acheter #l'amelioration de livraison# pour #{((SellingSpot)WorldObject).price} �mes# ? (Vous en avez #{PlayerMain.Instance.Stats.Money}#)", new string[] {"J'ach�te !", "J'ai chang� d'avis."});
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Geoffrrus.Say("Charon te livrera d�sormais plus d��mes chaque jours, � toi d�en prendre soin.");
                await _characters.Geoffrrus.Say("Oh, et ne te tracasse pas trop pour savoir comment il en trouve autant, tes semblables sont assez imaginatifs pour nous en fournir r�guli�rement en bonne quantit�.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Geoffrrus.Say("Ahahah, reviens donc quand tu auras plus de sous� Je ne risque pas de te faire cadeau de celle-ci !");
            }
        }       
        else if (resultat == 1)
        {
            await _characters.Geoffrrus.Say("NON MERCI ?! MAIS ! Ah, je ne comprendrais jamais votre esp�ce�");
        }

    }
}