using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


[Serializable]
public class DialogueFlow 
{
    
    private DialoguePanel _panel;
    [SerializeField] private DialogueCharacters characters;

    // Start is called before the first frame update
    public void init(DialoguePanel panel)
    {
        _panel = panel;
        characters.initAllCharacters(this,panel);
    }

    public async Task StartDialogue() 
    {
        _panel.InitDialogue(characters.Nestor, characters.Noah);
        
        await characters.Nestor.Say("Ta pute la mère noire oui c'est la mère noire yodelyodeliyodel ma grosse raclette poésie putain");
        await characters.Noah.Say("ouh là là ça fait mal ça aie aie aie caramba baba my world is upside down; cold sleep il all I found");
        await characters.Nestor.Say("la sale race de tes morts");
    }



}
