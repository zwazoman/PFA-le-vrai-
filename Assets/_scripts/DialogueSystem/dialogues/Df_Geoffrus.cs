using System.Threading.Tasks;
using UnityEngine;

public class Df_Geoffrus : DialogueFlow
{
    public Df_Geoffrus(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }
    bool _firstTalk;
    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Geoffrrus, _characters.Bobbus);
        if (_firstTalk)
        {
            await _characters.Geoffrrus.Say("Oh ? Et bien, si je m'y attendais... Cela faisais bien longtemps que je n'avais pas re�u de visite !");
            int result = await _characters.Geoffrrus.Ask("Qui �tes vous, donc, brave �me ? ", new string[] { "Vous �tes... un genre de d�mon ?", "Je suis le fermier, j'habite au bout du chemin.", "Bobbus. Je suis venu avec Charon il y a peu...", "Au revoir." });
            await _characters.Bobbus.Say("Louis est gay");
        }
    }
}
    