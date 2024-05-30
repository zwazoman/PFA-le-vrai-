using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Df_Tuto : DialogueFlow
{
    public Df_Tuto(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }


    async Task ExplanationPlant()
    {
        await _characters.Charon.Say("Vous allez voir, c�est enfantin ! Les �mes sont sous formes de petites graines, qu�ils vous suffit de planter dans le sol des parcelles.");
        await _characters.Charon.Say("Arrosez les, et apr�s quelques jours vous obtiendrez une belle fleur d��me toute pure que vous n�aurez qu�� r�colter avec une faux et apporter au moulin pour finir l�op�ration.");
        await _characters.Bobbus.Say("Et une fois que tout est fini ?");
    }

    async Task ExplanationTools()
    {
        await _characters.Charon.Say("Il vous suffit de pr�parer les parcelles avec une b�che, puis la plante se d�brouillera toute seule une fois mise en terre.");
        await _characters.Charon.Say("Faite attention, la corruption a cependant tendance � se� r�pandre de mani�re f�cheuse entre les pousses, et vous risquez de vous retrouvez avec un champ pourri.");
        await _characters.Charon.Say("Pour contrer �a, r�pandez un peu d�eau b�nite sur les plantes, �a devrait suffire.");
    }

    async Task ExplanationSoul()
    {
     

        await _characters.Charon.Say("Oh, c�est tr�s simple ! Disons qu�au vu de votre vie� mouvement�e, on vous laisse une chance de vous racheter.");
        await _characters.Charon.Say("Racheter votre �me, plus pr�cis�ment. Vous voyez ce sac ? Il contient un paquet d��mes comme la v�tre, encore pleines des p�ch�s de leur vie pass�e,");
        await _characters.Charon.Say("Occuper vous en, et vous parviendrez peut �tre � racheter votre �me et acc�der au paradis � votre tour.");
    }



    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Bobbus);

        await _characters.Charon.Say("C�est bon, vous �tes remis de vos �motions ? Je vous ai trouv� mort sur la rive du fleuve il y'a d�j� plusieurs heures.laissez-moi vous accueillir officiellement dans l�#au-del�!#");
      
        await _characters.Bobbus.Say("Mort ? Comment �a mort ? Je�");

      
        await _characters.Charon.Say("Votre nouvelle mission, mon jeune ami,sera de vous occuper ici d'#�mes# comme la votre, et de les #purifier# chaque jour. Vous devriez vous sentir honor�, �a n�est pas donn� � tout le monde !");
       

     await _characters.Charon.Say(
        " #Je reviendrais vous livrez des sacs ici m�me tous les jours#, jusqu�� ce que vous ayez ammass� assez d'argent pour me #racheter votre �me# � votre tour.");
        
        await _characters.Bobbus.Say("Et o� dois-je aller?");

        await _characters.Charon.Say("Continuez � l'#est# sur la route qui longe le fleuve, vous finirez par trouvez une ferme, votre nouvelle demeure ! Vous y trouverez votre nouvelle #brouette#, bien pratique pour transporter plusieurs objets � la fois.");
       
        int resultat=-1;
        while(resultat != 3)
        {
            resultat = await _characters.Bobbus.Ask(" Besoin que je r�p�te quoi que �a soit ?", new string[] { "Le cycle de plantation", "Les outils", "Le salut de mon �me", "Non merci" });

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