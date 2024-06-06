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
            await _characters.Geoffrrus.Say("Oh ? Et bien, si je m'y attendais... Cela faisais bien longtemps que je n'avais pas re�u de visite !");
            int result = await _characters.Geoffrrus.Ask("Qui �tes vous, donc, brave personne ? ", new string[] { "Et vous ?", "Un fermier", "Au revoir." });
            if (result == 0)
            {
                await _characters.Bobbus.Say("Vous �tes un genre de d�mon exactement ?");
                await _characters.Geoffrrus.Say("C'est exact. Un d�mon marchand pour �tre plus pr�cis");
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
                await _characters.Bobbus.Say("Le dernier ? Ah, oui j'ai r�cup�r� son herbier. Vous n'�tes pas le premier � me parler de lui, qui �tait il ?");
                await _characters.Geoffrrus.Say("C'�tait... votre pr�d�cesseur, c'est surement tout ce que vous avez besoin de savoir. Il venait souvent m'acheter des choses,");
                await _characters.Geoffrrus.Say("mais depuis son d�part, sa ferme a due tomber en d�cr�pitude, j'ai bien peur que tout soit � refaire... Heureusement, je suis l� pour cela !");
                await _characters.Bobbus.Say("Mouais... Je vais devoir tout vous racheter du coup ?");
                await _characters.Geoffrrus.Say("A moi, ou a Eve. C'est l'autre marchand de ce coin de l'enfer, vous la trouverez sur sa montagne dans un temple aussi grand que son �go. Nous vendons tous les deux des produits diff�rents.");
                await _characters.Bobbus.Say("Quelles sont les diff�rences exactement ?");
                await _characters.Geoffrrus.Say("Ici, vous pouvez acqu�rir diff�rentes am�liorations permanentes pour votre ferme et vos cultures, ou des clefs qui d�bloqueront diff�rentes parties des environs.");
                await _characters.Geoffrrus.Say("Chez l'Ange, vous pourrez acheter des potions ou des titres de propri�t�s pour vos parcelles, comme les terrains de la ferme lui appartiennent.");
                await _characters.Bobbus.Say("Bon, plus qu'� m'y mettre alors... Merci encore.");
            }
               
                 
            if (result == 2)
            {
                await _characters.Geoffrrus.Say("Bobbus ? Ca ne me dit rien... Si vous �tes venus avec Charon, j'esp�re qu'il vous a parl� de moi, au moins ?");
                await _characters.Bobbus.Say("Pas...pas exactement. Enfin, pas du tout m�me.");
                await _characters.Geoffrrus.Say("Je vais finir par mal le prendre. Et dire qu'il ne s'est m�me pas donn� la peine de venir de rendre visite...");
                await _characters.Bobbus.Say("Heu... Qui �tes vous exactement du coup ?");
                await _characters.Geoffrrus.Say("Je suis l'un des deux marchands de cet endroit perdu des enfers, mon bon ami.");
                await _characters.Geoffrrus.Say("Je vends des am�liorations permanentes pour votre ferme, vos outils et m�me certaines clefs. J'esp�re que pourront faire affaire, mon brave.");
                await _characters.Bobbus.Say("Comment cela marche, exactement ?");
                await _characters.Geoffrrus.Say("Ici, vous pouvez acqu�rir diff�rentes am�liorations permanentes pour votre ferme et vos cultures, ou des clefs qui d�bloqueront diff�rentes parties des environs.");
                await _characters.Geoffrrus.Say("Chez l'Ange, vous pourrez acheter des potions ou des titres de propri�t�s pour vos parcelles, comme les terrains de la ferme lui appartiennent.");
                await _characters.Bobbus.Say("Bon, plus qu'� m'y mettre alors... Merci encore.");
            }
              
            
            if (result == 3)
            {
               await _characters.Bobbus.Say("Au revoir.");
            }          

        }
    }
}

    