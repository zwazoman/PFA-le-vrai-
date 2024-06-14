using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Df_TutoAttente : DialogueFlow
{
    public Df_TutoAttente(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Bobbus, _characters.Charon);

        await _characters.Charon.Say("Bien, je vois que tes plantations progressent ! Laisse-leur le temps de pousser, et repasse demain matin. Profites-en pour #explorer# un peu autour de la ferme !.");
    }
}
