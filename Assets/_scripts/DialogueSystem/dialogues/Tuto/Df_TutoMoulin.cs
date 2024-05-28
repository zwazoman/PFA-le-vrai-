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

        await _characters.Charon.Say("Al... Allo ? Oui Bobbus ? C'est Charon ! Tu as récolté ta première orbe, bravo ! Malheureusement aucun marchand n'achèterait une chose aussi encombrante... Il te faut donc l'écraser et en faire de la poussière. Le moulin se trouve au nord. Bonne route !");
    }
}
