using System.Threading.Tasks;
using UnityEngine;

public class Df_Tuto : DialogueFlow
{
    public Df_Tuto(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }


    async Task ExplanationPlant()
    {
        await _characters.Charon.Say("B�cher vos champs, puis plantez-y vous vos graines");
        await _characters.Charon.Say("Arrosez les, et apr�s quelques jours vous obtiendrez une fleur d'�me, que vous n'aurez qu'� r�colter avec votre houe.");
        await _characters.Charon.Say("Faites attention toute fois avec vos plantes, elles se corrompront si vous ne les arrosez pas assez.");
    }

    async Task ExplanationTools()
    {
        await _characters.Charon.Say("Votre b�che vous servira � pr�parer vos champs.");
        await _characters.Charon.Say("Vous constaterez que vos plantes se corrompent si elles manquent d'entretien ; arrosez-les pour �viter cela.");
        await _characters.Charon.Say("Enfin, votre faux vous servira � r�colter les �mes arriv�es � maturit�");
    }

    async Task ExplanationSoul()
    {
     

        await _characters.Charon.Say("Votre vie n'a pas �t� l'exemple m�me de la saintet�");
        await _characters.Charon.Say("Vous allez devoir travaillez pour racheter votre �me... En vous occupant pour cela de celles des autres.");
        await _characters.Charon.Say("Purifiez les et vous finirez par gagner assez pour racheter la clef du paradis � l'Ange Eve");
    }



    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Bobbus, _characters.Charon);

        await _characters.Charon.Say("H� vous, enfin r�veill� ? Vous venez de franchir la fronti�re entre la vie et la mort, pas vrai ? Et vous avez atterri tout droit en enfer, comme tous vos pr�d�cesseurs.");
      
        await _characters.Bobbus.Say("En... Enfer ? Mais, pourquoi ?");
      
        await _characters.Charon.Say("Pour accomplir une mission ! Vous avez d�sormais la charge honorifique de vous occuper des �mes# des autres d�funts et de les #purifier.#");

        await _characters.Bobbus.Say("... J'imagine que je n'ai pas le choix ?");

        await _characters.Charon.Say("Aucunement ! Enfin, si vous voulez #racheter votre �me# tout du moins. Vous verrez, tout ce que vous avez � faire, c'est #planter les graines# que je vous #livre tous les deux jours#, et vous en occuper.");
        await _characters.Charon.Say("Je vous donnerais des informations sur la suite en temps voulu.");
       

     await _characters.Charon.Say("Je reviendrais vous #livrer des sacs ici m�me tous les deux jours#");
        
        await _characters.Bobbus.Say("Et o� dois-je commencer ?");

        await _characters.Charon.Say("Rejoignez la ferme. Vous y trouverez votre #brouette# et vos champs, dans lesquels vous pourrez commencer vos plantations.");
       
        int resultat=-1;
        while(resultat != 3)
        {
            resultat = await _characters.Bobbus.Ask("Besoin que je r�p�te quoi que ce soit ?", new string[] { "Le cycle de plantation", "Les outils", "Le salut de mon �me", "Non merci" });

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