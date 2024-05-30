using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Df_TutoAttente : DialogueFlow
{
    public Df_TutoAttente(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Bobbus);

        await _characters.Charon.Say("Bobbus ? Tu me reçois ? Tes plantations avancent bien ! Sache qu'une fois tes plantes arrosées tu dois #attendre# le #jour suivant# pour qu'elles #poussent#. Prends toi un peu de temps pour #explorer#, #dormir# dans ta maison ou faire du golf (DLC).");
    }
}
