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
        await _characters.B.Say("Et une fois que tout est fini ?");
    }

    async Task ExplanationTools()
    {
        await _characters.Charon.Say("Il vous suffit de pr�parer les parcelles avec une b�che, puis la plante se d�brouillera toute seule une fois mise en terre.");
        await _characters.Charon.Say("Faite attention, la corruption a cependant tendance � se� r�pandre de mani�re f�cheuse entre les pousses, et vous risquez de vous retrouvez avec un champ pourri.");
        await _characters.Charon.Say("Pour contrer �a, r�pandez un peu d�eau b�nite sur les plantes, �a devrait suffire.");
    }

    async Task ExplanationSoul()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Geoffrrus);

        await _characters.Charon.Say("Oh, c�est tr�s simple ! Disons qu�au vu de votre vie� mouvement�e, on vous laisse une chance de vous racheter.");
        await _characters.Charon.Say("Racheter votre �me, plus pr�cis�ment. Vous voyez ce sac ? Il contient un paquet d��mes comme la v�tre, encore pleines des p�ch�s de leur vie pass�e,");
        await _characters.Charon.Say("mais ne demandant qu�� acc�der � la f�licit� �ternelle du paradis� Et il vous incombe de vous en occuper");
    }



    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Bobbus);

        await _characters.Charon.Say("C�est bon, vous �tes remis de vos �motions ?");
        await _characters.Bobbus.Say("� Je� Je ne suis pas vraiment s�r de�ce que je fais l�, en premier lieu ?");

        await _characters.Charon.Say("Ahahah, c�est souvent comme �a au d�but. Et bien, laissez-moi vous accueillir officiellement dans l�au-del�.");
        await _characters.Bobbus.Say("Mort ? Comment �a mort ? Je�");

        await _characters.Charon.Say("Aussi mort que je vous vois, oui. Mais ne vous en faites pas, on le vit tr�s bien.");
        await _characters.Bobbus.Say("�.");

        await _characters.Charon.Say("�.");
        await _characters.Bobbus.Say("� Et donc, c�est �a l�au-del� ? Qu�est ce qu�il se passe maintenant ?");

        await _characters.Charon.Say("Oh, c�est tr�s simple ! Disons qu�au vu de votre vie� mouvement�e, on vous laisse une chance de vous racheter.");
        await _characters.Charon.Say("Racheter votre �me, plus pr�cis�ment. Vous voyez ce sac ? Il contient un paquet d��mes comme la v�tre, encore pleines des p�ch�s de leur vie pass�e,");
        await _characters.Charon.Say("mais ne demandant qu�� acc�der � la f�licit� �ternelle du paradis� Et il vous incombe de vous en occuper");
        await _characters.Geoffrrus.Say("Comment �a m�en occuper ? Attendez, qu�est ce que c�est que cette histoire ?");

        await _characters.Charon.Say("C�est votre nouvelle mission, mon jeune ami. Vous devriez vous sentir honor�, �a n�est pas donn� � tout le monde !");
        await _characters.Geoffrrus.Say("Je� Je ne sais pas exactement comment le prendre. Comment �a s�entretient une �me en premier lieu ?");

        await _characters.Charon.Say("Vous allez voir, c�est enfantin ! Les �mes sont sous formes de petites graines, qu�ils vous suffit de planter dans le sol des parcelles.");
        await _characters.Charon.Say("Arrosez les, et apr�s quelques jours vous obtiendrez une belle fleur d��me toute pure que vous n�aurez qu�� r�colter avec une faux et apporter au moulin pour finir l�op�ration.");
        await _characters.Bobbus.Say("Et une fois que tout est fini ?");

        await _characters.Charon.Say("Vous recommencez, quelle question. Je reviendrais vous livrez des sacs ici m�me tous les [�] jours, jusqu�� ce qu�Ils consid�rent que vous ayez assez travaill�s pour me racheter votre �me � votre tour.");
        await _characters.Bobbus.Say("� ��Ils�� ?");

        await _characters.Charon.Say("Eux. Enfin, ceux qui dirigent l�endroit, disons. Ceux que les v�tres appellent des Dieux, ou en tout cas ce qui s�en rapprochent le plus.");
        await _characters.Charon.Say("Ne vous tracassez pas avec les d�tails administratifs, tout viendra en son temps.");
        await _characters.Bobbus.Say("�Ahem. Et pour en revenir aux plantes ? Comment je les entretiens ?");

        await _characters.Charon.Say("Il vous suffit de pr�parer les parcelles avec une b�che, puis la plante se d�brouillera toute seule une fois mise en terre.");
        await _characters.Charon.Say("Faite attention, la corruption a cependant tendance � se� r�pandre de mani�re f�cheuse entre les pousses, et vous risquez de vous retrouvez avec un champ pourri.");
        await _characters.Charon.Say("Pour contrer �a, r�pandez un peu d�eau b�nite sur les plantes, �a devrait suffire.");
        await _characters.Bobbus.Say("Et o� est-ce que je suis cens� trouver tout �a ?");

        await _characters.Charon.Say("Continuez sur la route qui longe le fleuve, vous finirez par trouvez une ferme, votre nouvelle demeure !");
        await _characters.Charon.Say("Une fois l� bas, vous aurez tout le mat�riel n�cessaire pour accomplir votre devoir, notamment une brouette pour le transport des �mes.");
        await _characters.Bobbus.Say("Ca fait beaucoup � assimiler d�un coup�");

        await _characters.Charon.Say("Regardez dans la maison, il y a un manuel qui r�sume tout ce que je viens de vous expliquez.Votre pr�d�cesseur a eu la bonne id�e de compiler plusieurs de ses observations dans un herbier.");
        await _characters.Bobbus.Say("Mon pr�d�cesseur ? Combien de gens comme moi ce sont retrouv�s ici avant moi exactement ?");

        _characters.Charon.SetEmotion(DialogueCharacter.Emotions.Happy);
        int resultat=-1;
        while(resultat != 4)
        {
            resultat = await _characters.Geoffrrus.Ask("Vous n�avez pas besoin de le savoir. Besoin que je r�p�te quoi que �a soit ?", new string[] { "Le cycle de plantation", "Les outils", "Le salut de mon �me", "Non merci" });

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
        await _characters.Charon.Say("Bien, parfait, vous voil� fin pr�t � remplir votre devoir !");
        await _characters.Bobbus.Say("Plus qu�� m�y mettre� ");
        
        await _characters.Charon.Say("Je repasserai dans [�] jours, bonne chance pour votre plantation d�ici l�, ahahah Charon s�en va sur son bateau");
    }

}