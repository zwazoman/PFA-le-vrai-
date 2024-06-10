using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Df_SowSeedReward : DialogueFlow
{
    public Df_SowSeedReward(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Charon, _characters.Bobbus);
        await _characters.Charon.Say("Un petit cadeau pour toi, Bobbus ! Maintenant que tu as r�colt�s ta premi�re orbe, voil� la clef qui te m�nera au moulin, plus au nord. Tu n'as plus qu'� transformer l'�me en poussi�re, et le tour est jou� !");
        Debug.Log(WorldObject);
        ((QuestReward)WorldObject).GiveObject();
    }
}
