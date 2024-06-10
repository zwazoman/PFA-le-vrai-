using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Df_TutoMoulin : DialogueFlow
{
    public Df_TutoMoulin(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Bobbus);

        await _characters.Charon.Say("Bravo Bobbus, tu tiens entre tes mains ta premi�re #�me purifi�e# de ses p�ch�s ! Maintenant, il ne te reste plus qu'� la #transformer en poussi�re d'�me# pour la lib�rer. Rends toi au #moulin plus au nord# pour cela.");
    }
}
