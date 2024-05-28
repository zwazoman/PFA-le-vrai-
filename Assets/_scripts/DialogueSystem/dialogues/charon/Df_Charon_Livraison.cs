using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Df_Charon_Livraison : DialogueFlow
{
    public Df_Charon_Livraison(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    List<string> dialogue1 = new List<string>()
    {
        "Tiens, voil� tes graines comme d'habitude Bobbus.",
        "Tiens, voil� une nouvelle livraison de graines rien que pour toi Bobbus.",
        "D�sol� pour le d�lai,voici tes nouvelles graines.",
        "J'ai entendu dire que �a grondait l�-haut. �a va encore �tre le bazar au centre de tri",
        "Le patron n'�tait pas content aujourd'hui, j'espere que tu t'occuperas correctement de toutes ses graines.",
        "Mon grand p�re disait souvent:\r\n \" Boom na da mmm dum na ema \r\n Da boom na da mmm dum na ema  \" \r\n ... Aucune id�e de ce que �a signifie. ",
        "voici tes graines Bobbus. Elles sont toutes fraiches, c'est jeudi. ",
        "Un moustique, ma li... pardon,j'�tais ailleurs.",
        "...",
        "Ma femme m'a quitt� Bobbus.",
        "�a sent le poisson? bizarre. Voici tes graines.",
        "Tu sais Bobbus, je me demande parfois si je n'�tais pas livreur de pizzas dans une autre vie. Enfin bon, en tous cas voici tes graines.",
        "Ma vie n'est qu'un cercle monotone Bobbus. Je n'en peux plus. J'ai besoin d'un nouvel air. Termine vite ce jeu veux-tu ?"
    };

    List<string> dialogue2 = new List<string>()
    {

        "Je repasserai demain � 7h. N'oublie pas d'etre pr�sent si tu veux de nouvelles graines.",
        "N'oublie pas de venir vers 7h si tu ne veux pas me louper. J'ai beaucoup de travail ces jours-ci.",
        "�a fait beaucoup, n'oublies pas de venir avec ta brouette.",
        "� demain Bobbus,pense bien � venir �quipp� de ta brouette.",
        "Adieu",
        "� la revoyure.",
        "Au revoir.",
        "Au revoir Bobbus.",
        "Salutations.",
        "La bise.",
        "La bise.",
        "C'est Ciao.",
        "...",
    };

    public override async Task StartDialogue()
    { 
        _panel.InitDialogue(_characters.Bobbus, _characters.Charon);

        await _characters.Charon.Say(dialogue1[Random.Range(0,dialogue1.Count)]);
        await _characters.Charon.Say(dialogue2[Random.Range(0,dialogue2.Count)]);

       
    }
}

