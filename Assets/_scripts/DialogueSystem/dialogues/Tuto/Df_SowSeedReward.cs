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
        Debug.Log("==============================================================================");

        await _characters.Charon.Say("BOBBUS ! ATTRAPE ! J'ai vu que tu avais récolté tes premières #orbes#. Voici la #clef# qui t'ouvrira l'acces au #moulin# en récompense. Tu peux y apporter tes #orbes# pour en faire de la #poussière d'âme# et t'acheter des bricoles chez #Geoffrus#.");
        Debug.Log("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
       

        if((WorldObject != null))
        {
            WorldObject.SendMessage("GiveObject", SendMessageOptions.DontRequireReceiver);

        }
        else
        {
            Debug.Log("Il est nul ton script de con, tu te démerdes");
        }
        
    }
}
