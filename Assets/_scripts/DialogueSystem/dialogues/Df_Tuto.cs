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
        await _characters.B.Say("Et une fois que tout est fini ?");
    }

    async Task ExplanationTools()
    {
        await _characters.Charon.Say("Il vous suffit de préparer les parcelles avec une bêche, puis la plante se débrouillera toute seule une fois mise en terre.");
        await _characters.Charon.Say("Faite attention, la corruption a cependant tendance à se… répandre de manière fâcheuse entre les pousses, et vous risquez de vous retrouvez avec un champ pourri.");
        await _characters.Charon.Say("Pour contrer ça, répandez un peu d’eau bénite sur les plantes, ça devrait suffire.");
    }

    async Task ExplanationSoul()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Geoffrrus);

        await _characters.Charon.Say("Oh, c’est très simple ! Disons qu’au vu de votre vie… mouvementée, on vous laisse une chance de vous racheter.");
        await _characters.Charon.Say("Racheter votre âme, plus précisément. Vous voyez ce sac ? Il contient un paquet d’âmes comme la vôtre, encore pleines des pêchés de leur vie passée,");
        await _characters.Charon.Say("mais ne demandant qu’à accéder à la félicité éternelle du paradis… Et il vous incombe de vous en occuper");
    }



    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Bobbus);

        await _characters.Charon.Say("C’est bon, vous êtes remis de vos émotions ?");
        await _characters.Bobbus.Say("… Je… Je ne suis pas vraiment sûr de…ce que je fais là, en premier lieu ?");

        await _characters.Charon.Say("Ahahah, c’est souvent comme ça au début. Et bien, laissez-moi vous accueillir officiellement dans l’au-delà.");
        await _characters.Bobbus.Say("Mort ? Comment ça mort ? Je…");

        await _characters.Charon.Say("Aussi mort que je vous vois, oui. Mais ne vous en faites pas, on le vit très bien.");
        await _characters.Bobbus.Say("….");

        await _characters.Charon.Say("….");
        await _characters.Bobbus.Say("… Et donc, c’est ça l’au-delà ? Qu’est ce qu’il se passe maintenant ?");

        await _characters.Charon.Say("Oh, c’est très simple ! Disons qu’au vu de votre vie… mouvementée, on vous laisse une chance de vous racheter.");
        await _characters.Charon.Say("Racheter votre âme, plus précisément. Vous voyez ce sac ? Il contient un paquet d’âmes comme la vôtre, encore pleines des pêchés de leur vie passée,");
        await _characters.Charon.Say("mais ne demandant qu’à accéder à la félicité éternelle du paradis… Et il vous incombe de vous en occuper");
        await _characters.Geoffrrus.Say("Comment ça m’en occuper ? Attendez, qu’est ce que c’est que cette histoire ?");

        await _characters.Charon.Say("C’est votre nouvelle mission, mon jeune ami. Vous devriez vous sentir honoré, ça n’est pas donné à tout le monde !");
        await _characters.Geoffrrus.Say("Je… Je ne sais pas exactement comment le prendre. Comment ça s’entretient une âme en premier lieu ?");

        await _characters.Charon.Say("Vous allez voir, c’est enfantin ! Les âmes sont sous formes de petites graines, qu’ils vous suffit de planter dans le sol des parcelles.");
        await _characters.Charon.Say("Arrosez les, et après quelques jours vous obtiendrez une belle fleur d’âme toute pure que vous n’aurez qu’à récolter avec une faux et apporter au moulin pour finir l’opération.");
        await _characters.Bobbus.Say("Et une fois que tout est fini ?");

        await _characters.Charon.Say("Vous recommencez, quelle question. Je reviendrais vous livrez des sacs ici même tous les […] jours, jusqu’à ce qu’Ils considèrent que vous ayez assez travaillés pour me racheter votre âme à votre tour.");
        await _characters.Bobbus.Say("… ‘’Ils’’ ?");

        await _characters.Charon.Say("Eux. Enfin, ceux qui dirigent l’endroit, disons. Ceux que les vôtres appellent des Dieux, ou en tout cas ce qui s’en rapprochent le plus.");
        await _characters.Charon.Say("Ne vous tracassez pas avec les détails administratifs, tout viendra en son temps.");
        await _characters.Bobbus.Say("…Ahem. Et pour en revenir aux plantes ? Comment je les entretiens ?");

        await _characters.Charon.Say("Il vous suffit de préparer les parcelles avec une bêche, puis la plante se débrouillera toute seule une fois mise en terre.");
        await _characters.Charon.Say("Faite attention, la corruption a cependant tendance à se… répandre de manière fâcheuse entre les pousses, et vous risquez de vous retrouvez avec un champ pourri.");
        await _characters.Charon.Say("Pour contrer ça, répandez un peu d’eau bénite sur les plantes, ça devrait suffire.");
        await _characters.Bobbus.Say("Et où est-ce que je suis censé trouver tout ça ?");

        await _characters.Charon.Say("Continuez sur la route qui longe le fleuve, vous finirez par trouvez une ferme, votre nouvelle demeure !");
        await _characters.Charon.Say("Une fois là bas, vous aurez tout le matériel nécessaire pour accomplir votre devoir, notamment une brouette pour le transport des âmes.");
        await _characters.Bobbus.Say("Ca fait beaucoup à assimiler d’un coup…");

        await _characters.Charon.Say("Regardez dans la maison, il y a un manuel qui résume tout ce que je viens de vous expliquez.Votre prédécesseur a eu la bonne idée de compiler plusieurs de ses observations dans un herbier.");
        await _characters.Bobbus.Say("Mon prédécesseur ? Combien de gens comme moi ce sont retrouvés ici avant moi exactement ?");

        _characters.Charon.SetEmotion(DialogueCharacter.Emotions.Happy);
        int resultat=-1;
        while(resultat != 4)
        {
            resultat = await _characters.Geoffrrus.Ask("Vous n’avez pas besoin de le savoir. Besoin que je répète quoi que ça soit ?", new string[] { "Le cycle de plantation", "Les outils", "Le salut de mon âme", "Non merci" });

            if (resultat == 1)
            {
                await ExplanationPlant();
            }

            if (resultat == 2)
            {
                await ExplanationTools();
            }

            if(resultat == 3)
            {
                await ExplanationSoul();
            }
        }
        await _characters.Charon.Say("Bien, parfait, vous voilà fin prêt à remplir votre devoir !");
        await _characters.Bobbus.Say("Plus qu’à m’y mettre… ");
        
        await _characters.Charon.Say("Je repasserai dans […] jours, bonne chance pour votre plantation d’ici là, ahahah Charon s’en va sur son bateau");
    }

}