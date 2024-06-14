using System.Threading.Tasks;
using UnityEngine;

public class Df_TutoMoulin : DialogueFlow
{
    public Df_TutoMoulin(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Bobbus, _characters.Charon);

        await _characters.Charon.Say("Ta première âme purifiée... Ca doit faire quelque chose n'est-ce pas ? Il ne te reste plus qu'à #l'amener au moulin, au nord#, pour en faire de la #poussière d'âme# et tu auras terminé !");
    }
}
