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

        await _characters.Charon.Say("Bravo Bobbus, tu tiens entre tes mains ta première #âme purifiée# de ses péchés ! Maintenant, il ne te reste plus qu'à la #transformer en poussière d'âme# pour la libérer. Rends toi au #moulin plus au nord# pour cela.");
    }
}
