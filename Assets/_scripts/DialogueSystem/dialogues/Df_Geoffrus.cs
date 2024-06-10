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
                await _characters.Bobbus.Say("Vous �tes un genre de d�mon ?");
                await _characters.Geoffrrus.Say("C'est exact. Un d�mon marchand pour �tre plus pr�cis.");
                await _characters.Bobbus.Say("Marchand... Marchand de quoi exactement ?");
                await _characters.Geoffrrus.Say("De tout ce que tu vois autour de toi ! Brouette, clef, potion... Tout un tas de babioles qui sont � ta disposition, pour peu que tu saches y mettre le prix.");
                await _characters.Bobbus.Say("Le prix... Vous parlez de poussi�re d'�me n'est ce pas ?");
                await _characters.Geoffrrus.Say("Aaaaah... Exactement ! Voil� ce que j'aime entendre. Am�ne-moi de cette poussi�re, et nous pourrons faire affaire.");
                await _characters.Bobbus.Say("Tr�s bien.");
            }   
               
            if (result == 1)
            {
                await _characters.Geoffrrus.Say("Ah, le nouveau fermier ? Ca faisait longtemps depuis le dernier en date...");
                await _characters.Bobbus.Say("Le dernier ? Combien avons nous �t� � servir ici, exactement. Et qui �tait-il ?");
                await _characters.Geoffrrus.Say("C'�tait... votre pr�d�cesseur, c'est surement tout ce que vous avez besoin de savoir. Il venait souvent m'acheter des choses,");
                await _characters.Geoffrrus.Say("mais depuis son d�part, sa ferme a due tomber en d�cr�pitude, j'ai bien peur que tout soit � refaire... Heureusement, je suis l� pour cela !");
                await _characters.Bobbus.Say("Mouais... Je vais devoir tout vous racheter du coup ?");
                await _characters.Geoffrrus.Say("A moi, oui. Je suis l'unique marchand de cet endroit.");
                await _characters.Bobbus.Say("Quel genre de bien vendez-vous ?");
                await _characters.Geoffrrus.Say("Ici, vous pouvez acqu�rir diff�rentes am�liorations permanentes pour vos cultures, des potions ou des clefs qui d�bloqueront diff�rentes parties des environs.");
                await _characters.Bobbus.Say("Bon, plus qu'� m'y mettre alors... Merci encore.");
            }
  
            
            if (result == 2)
            {
               await _characters.Bobbus.Say("Au revoir.");
            }          

        }
    }
}

    