using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class DialogueFlow 
{

    private DialoguePanel _panel;
    [SerializeField] private DialogueCharacters characters;

    // Start is called before the first frame update
    public void init(DialoguePanel panel)
    {
        _panel = panel;

    }

    public async Task StartDialogue() 
    {
        _panel.InitDialogue(characters.Nestor, characters.Noah);
        await characters.Nestor.Say("Ta pute la mère");
        await characters.Noah.Say("ouh");
        await characters.Nestor.Say("la sale race de tes morts");
    }



}
