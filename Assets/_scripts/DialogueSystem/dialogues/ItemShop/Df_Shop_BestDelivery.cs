using System.Threading.Tasks;
using UnityEngine;

public class Df_Shop_BestDelivery : DialogueFlow
{
    public Df_Shop_BestDelivery(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Quentin, _characters.Noah);

        await _characters.Noah.Say("Aaah, je me demandais quand tu allais venir la prendre, celle-ci. Il te suffit de l’activer, et tu auras une livraison d’âmes plus importante de la part de Charon. Une vrai petite merveille.");
        await _characters.Noah.Say($"Je te le vend pour seulement {((SellingSpot)WorldObject).price} bitcoins! Quelle affaire!");

        int resultat = await _characters.Narrator.Ask("Voulez vous acheter cet Objet ?", new string[] { "J'achète !", "J'ai changé d'avis.", "Je négocie" });
        if (resultat == 0)
        {
            if (((SellingSpot)WorldObject).price <= PlayerMain.Instance.Stats.Money)
            {
                await _characters.Noah.Say("Charon te livrera désormais plus d’âmes chaque jours, à toi d’en prendre soin.");
                await _characters.Noah.Say("Oh, et ne te tracasse pas trop pour savoir comment il en trouve autant, tes semblables sont assez imaginatifs pour nous en fournir régulièrement en bonne quantité.");
                WorldObject.SendMessage("SellItem");
            }
            else
            {
                await _characters.Noah.Say("Ahahah, reviens donc quand tu auras plus de sous… Je ne risque pas de te faire cadeau de celle-ci !");
            }
        }       
        else if (resultat == 1)
        {
            await _characters.Noah.Say("NON MERCI ?! MAIS ! Ah, je ne comprendrais jamais votre espèce…");
        }
        else if(resultat == 2)
        {
            int resultat2 = await _characters.Narrator.Ask($"C’était celle de ton prédécesseur, alors je suppose qu’elle mérite de retourner à la ferme… J’en demande {(int)(((SellingSpot)WorldObject).price * 0.8f)} bitcoins pour l’occasion, estime toi heureux. ", new string[] { "J'achète !", "Non merci." });
            if (resultat2 == 0)
            {
                if ((int)(((SellingSpot)WorldObject).price * 0.8f) <= PlayerMain.Instance.Stats.Money)
                {
                    ((SellingSpot)WorldObject).price = (int)(((SellingSpot)WorldObject).price * 0.8f);
                    await _characters.Noah.Say("Charon te livrera désormais plus d’âmes chaque jours, à toi d’en prendre soin. Oh, et ne te tracasse pas trop pour savoir comment il en trouve autant,  tes semblables sont assez imaginatifs pour nous en fournir régulièrement en bonne quantité.");
                    WorldObject.SendMessage("SellItem");
                }
                else
                {
                    await _characters.Noah.Say("Hmmm pour le confort qu’elle t’offre, je pense que cette brouette vaut bien le prix que j’en demande.");
                }
            }
            else
            {
                await _characters.Noah.Say("NON MERCI ?! MAIS ! Ah, je ne comprendrais jamais votre espèce…");
            }
        }
    }
}