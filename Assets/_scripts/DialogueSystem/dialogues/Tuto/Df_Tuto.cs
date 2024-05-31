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

        await _characters.Charon.Say("C’est bon, vous êtes remis de vos émotions ? Je vous ai trouvé mort sur la rive du fleuve il y'a déjà plusieurs heures.laissez-moi vous accueillir officiellement dans l’#au-delà!#");
      
        await _characters.Bobbus.Say("Mort ? Comment ça mort ? Je…");

      
        await _characters.Charon.Say("Votre nouvelle mission, mon jeune ami,sera de vous occuper ici d'#âmes# comme la votre, et de les #purifier# chaque jour. Vous devriez vous sentir honoré, ça n’est pas donné à tout le monde !");
       

     await _characters.Charon.Say(
        " #Je reviendrais vous livrez des sacs ici même tous les jours#, jusqu’à ce que vous ayez ammassé assez d'argent pour me #racheter votre âme# à votre tour.");
        
        await _characters.Bobbus.Say("Et où dois-je aller?");

        await _characters.Charon.Say("Continuez à l'#est# sur la route qui longe le fleuve, vous finirez par trouvez une ferme, votre nouvelle demeure ! Vous y trouverez votre nouvelle #brouette#, bien pratique pour transporter plusieurs objets à la fois.");
       
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