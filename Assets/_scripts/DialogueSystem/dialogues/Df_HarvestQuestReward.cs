using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Df_HarvestQuestReward : DialogueFlow
{
    public Df_HarvestQuestReward(DialoguePanel panel, DialogueCharacters characters, MonoBehaviour WorldObject) : base(panel, characters, WorldObject) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Bobbus, _characters.Charon);

        await _characters.Charon.Say("HEY BOBBUS ! ATTRAPE ! Voici la #clef# pour ouvrir #la porte vers moulin#. Tu peux y apporter tes #orbes# pour les #broyer# et en faire de la #poussière d'âme#. Tu peux les échanger contre des breloques auprès de #Geoffrus#.");
        ((QuestReward)WorldObject).GiveReward();
    }
}
