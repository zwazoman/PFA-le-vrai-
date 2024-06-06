using System.Threading.Tasks;
using UnityEngine;

public class Df_Geoffrus : DialogueFlow
{
    public Df_Geoffrus(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }
    bool _firstTalk = true;
    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Geoffrrus, _characters.Bobbus);
        if (_firstTalk)
        {
            await _characters.Geoffrrus.Say("Oh ? Et bien, si je m'y attendais... Cela faisais bien longtemps que je n'avais pas reçu de visite !");
            int result = await _characters.Geoffrrus.Ask("Qui êtes vous, donc, brave personne ? ", new string[] { "Et vous ?", "Un fermier", "Au revoir." });
            if (result == 0)
            {
                await _characters.Bobbus.Say("Vous êtes un genre de démon exactement ?");
                await _characters.Geoffrrus.Say("C'est exact. Un démon marchand pour être plus précis");
                /*await _characters.Bobbus.Say("");
                await _characters.Geoffrrus.Say("");
                await _characters.Bobbus.Say("");
                await _characters.Geoffrrus.Say("");
                await _characters.Geoffrrus.Say("");
                await _characters.Bobbus.Say("");*/
            }   
               
            if (result == 1)
            {
                await _characters.Geoffrrus.Say("Ah, le nouveau fermier ? Ca faisait longtemps depuis le dernier en date...");
                await _characters.Bobbus.Say("Le dernier ? Ah, oui j'ai récupéré son herbier. Vous n'êtes pas le premier à me parler de lui, qui était il ?");
                await _characters.Geoffrrus.Say("C'était... votre prédécesseur, c'est surement tout ce que vous avez besoin de savoir. Il venait souvent m'acheter des choses,");
                await _characters.Geoffrrus.Say("mais depuis son départ, sa ferme a due tomber en décrépitude, j'ai bien peur que tout soit à refaire... Heureusement, je suis là pour cela !");
                await _characters.Bobbus.Say("Mouais... Je vais devoir tout vous racheter du coup ?");
                await _characters.Geoffrrus.Say("A moi, ou a Eve. C'est l'autre marchand de ce coin de l'enfer, vous la trouverez sur sa montagne dans un temple aussi grand que son égo. Nous vendons tous les deux des produits différents.");
                await _characters.Bobbus.Say("Quelles sont les différences exactement ?");
                await _characters.Geoffrrus.Say("Ici, vous pouvez acquérir différentes améliorations permanentes pour votre ferme et vos cultures, ou des clefs qui débloqueront différentes parties des environs.");
                await _characters.Geoffrrus.Say("Chez l'Ange, vous pourrez acheter des potions ou des titres de propriétés pour vos parcelles, comme les terrains de la ferme lui appartiennent.");
                await _characters.Bobbus.Say("Bon, plus qu'à m'y mettre alors... Merci encore.");
            }
               
                 
            if (result == 2)
            {
                await _characters.Geoffrrus.Say("Bobbus ? Ca ne me dit rien... Si vous êtes venus avec Charon, j'espère qu'il vous a parlé de moi, au moins ?");
                await _characters.Bobbus.Say("Pas...pas exactement. Enfin, pas du tout même.");
                await _characters.Geoffrrus.Say("Je vais finir par mal le prendre. Et dire qu'il ne s'est même pas donné la peine de venir de rendre visite...");
                await _characters.Bobbus.Say("Heu... Qui êtes vous exactement du coup ?");
                await _characters.Geoffrrus.Say("Je suis l'un des deux marchands de cet endroit perdu des enfers, mon bon ami.");
                await _characters.Geoffrrus.Say("Je vends des améliorations permanentes pour votre ferme, vos outils et même certaines clefs. J'espère que pourront faire affaire, mon brave.");
                await _characters.Bobbus.Say("Comment cela marche, exactement ?");
                await _characters.Geoffrrus.Say("Ici, vous pouvez acquérir différentes améliorations permanentes pour votre ferme et vos cultures, ou des clefs qui débloqueront différentes parties des environs.");
                await _characters.Geoffrrus.Say("Chez l'Ange, vous pourrez acheter des potions ou des titres de propriétés pour vos parcelles, comme les terrains de la ferme lui appartiennent.");
                await _characters.Bobbus.Say("Bon, plus qu'à m'y mettre alors... Merci encore.");
            }
              
            
            if (result == 3)
            {
               await _characters.Bobbus.Say("Au revoir.");
            }          

        }
    }
}

    