using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Df_SowSeedReward : DialogueFlow
{
    public Df_SowSeedReward(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Bobbus, _characters.Charon);
        await _characters.Charon.Say("Boobus ! Attrape ! Maintenant que tu as récolté ta première #orbe#, voilà la #clef# qui te mènera au #moulin#, plus au nord. Tu n'as plus qu'à transformer l'#âme# en #poussière#, et le tour est joué !");
        Debug.Log(WorldObject);
        ((QuestReward)WorldObject).GiveObject();
    }
}
