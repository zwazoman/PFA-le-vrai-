using System.Threading.Tasks;
using UnityEngine;

public class Df_Tuto : DialogueFlow
{
    public Df_Tuto(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }


    async Task ExplanationPlant()
    {
        await _characters.Charon.Say("Bêcher vos champs, puis plantez-y vous vos graines");
        await _characters.Charon.Say("Arrosez les, et après quelques jours vous obtiendrez une fleur d'âme, que vous n'aurez qu'à récolter avec votre houe.");
        await _characters.Charon.Say("Faites attention toute fois avec vos plantes, elles se corrompront si vous ne les arrosez pas assez.");
    }

    async Task ExplanationTools()
    {
        await _characters.Charon.Say("Votre bêche vous servira à préparer vos champs.");
        await _characters.Charon.Say("Vous constaterez que vos plantes se corrompent si elles manquent d'entretien ; arrosez-les pour éviter cela.");
        await _characters.Charon.Say("Enfin, votre faux vous servira à récolter les âmes arrivées à maturité");
    }

    async Task ExplanationSoul()
    {
     

        await _characters.Charon.Say("Votre vie n'a pas été l'exemple même de la sainteté");
        await _characters.Charon.Say("Vous allez devoir travaillez pour racheter votre âme... En vous occupant pour cela de celles des autres.");
        await _characters.Charon.Say("Purifiez les et vous finirez par gagner assez pour racheter la clef du paradis à l'Ange Eve");
    }



    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Bobbus, _characters.Charon);

        await _characters.Charon.Say("Hé vous, enfin réveillé ? Vous venez de franchir la frontière entre la vie et la mort, pas vrai ? Et vous avez atterri tout droit en enfer, comme tous vos prédécesseurs.");
      
        await _characters.Bobbus.Say("En... Enfer ? Mais, pourquoi ?");
      
        await _characters.Charon.Say("Pour accomplir une mission ! Vous avez désormais la charge honorifique de vous occuper des âmes# des autres défunts et de les #purifier.#");

        await _characters.Bobbus.Say("... J'imagine que je n'ai pas le choix ?");

        await _characters.Charon.Say("Aucunement ! Enfin, si vous voulez #racheter votre âme# tout du moins. Vous verrez, tout ce que vous avez à faire, c'est #planter les graines# que je vous #livre tous les deux jours#, et vous en occuper.");
        await _characters.Charon.Say("Je vous donnerais des informations sur la suite en temps voulu.");
       

     await _characters.Charon.Say("Je reviendrais vous #livrer des sacs ici même tous les deux jours#");
        
        await _characters.Bobbus.Say("Et où dois-je commencer ?");

        await _characters.Charon.Say("Rejoignez la ferme. Vous y trouverez votre #brouette# et vos champs, dans lesquels vous pourrez commencer vos plantations.");
       
        int resultat=-1;
        while(resultat != 3)
        {
            resultat = await _characters.Bobbus.Ask("Besoin que je répète quoi que ce soit ?", new string[] { "Le cycle de plantation", "Les outils", "Le salut de mon âme", "Non merci" });

            if (resultat == 0)
            {
                await ExplanationPlant();
            }

            if (resultat == 1)
            {
                await ExplanationTools();
            }

            if(resultat == 2)
            {
                await ExplanationSoul();
            }
        }
        
        await _characters.Charon.Say("Bonne Chance!");
        
    }

}