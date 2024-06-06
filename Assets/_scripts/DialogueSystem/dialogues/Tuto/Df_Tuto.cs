using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Df_Tuto : DialogueFlow
{
    public Df_Tuto(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }


    async Task ExplanationPlant()
    {
        await _characters.Charon.Say("Vous allez voir, c’est enfantin ! Les âmes sont sous formes de petites graines, qu’ils vous suffit de planter dans le sol des parcelles.");
        await _characters.Charon.Say("Arrosez les, et après quelques jours vous obtiendrez une belle fleur d’âme toute pure que vous n’aurez qu’à récolter avec une faux et apporter au moulin pour finir l’opération.");
        await _characters.Bobbus.Say("Et une fois que tout est fini ?");
    }

    async Task ExplanationTools()
    {
        await _characters.Charon.Say("Il vous suffit de préparer les parcelles avec une bêche, puis la plante se débrouillera toute seule une fois mise en terre.");
        await _characters.Charon.Say("Faite attention, la corruption a cependant tendance à se… répandre de manière fâcheuse entre les pousses, et vous risquez de vous retrouvez avec un champ pourri.");
        await _characters.Charon.Say("Pour contrer ça, répandez un peu d’eau bénite sur les plantes, ça devrait suffire.");
    }

    async Task ExplanationSoul()
    {
     

        await _characters.Charon.Say("Oh, c’est très simple ! Disons qu’au vu de votre vie… mouvementée, on vous laisse une chance de vous racheter.");
        await _characters.Charon.Say("Racheter votre âme, plus précisément. Vous voyez ce sac ? Il contient un paquet d’âmes comme la vôtre, encore pleines des pêchés de leur vie passée,");
        await _characters.Charon.Say("Occuper vous en, et vous parviendrez peut être à racheter votre âme et accéder au paradis à votre tour.");
    }



    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Bobbus);

        await _characters.Charon.Say("Hé vous, enfin réveillé ? Vous venez de franchir la frontière entre la vie et la mort, pas vrai ? Et vous avez atteri tout droit en enfer, comme tous vos prédécesseurs.");
      
        await _characters.Bobbus.Say("");

      
        await _characters.Charon.Say("Votre nouvelle mission, mon jeune ami,sera de vous occuper ici d'#âmes# comme la votre, et de les #purifier# chaque jour. Vous devriez vous sentir honoré, ça n’est pas donné à tout le monde !");
       

     await _characters.Charon.Say(
        " #Je reviendrais vous livrez des sacs ici même tous les deux jours#, jusqu’à ce que vous ayez ammassé assez d'argent pour #racheter votre âme# à la gardienne des portes du paradis, #l'Ange Eve#.");
        
        await _characters.Bobbus.Say("Et où dois-je commencer ?");

        await _characters.Charon.Say("Rejoingez la ferme. Vous y trouverez votre #brouette# et vos champs, dans lesquels vous pourrez commencez vos plantations.");
       
        int resultat=-1;
        while(resultat != 3)
        {
            resultat = await _characters.Bobbus.Ask(" Besoin que je répète quoi que ça soit ?", new string[] { "Le cycle de plantation", "Les outils", "Le salut de mon âme", "Non merci" });

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