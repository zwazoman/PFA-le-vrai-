using System;
using System.Threading.Tasks;
using UnityEngine;



/// <summary>
/// Les enfants de cette classe sont utilisés pour écrire les dialogues entre deux personnages.
/// Ils sont à mettre dans le dossier Assets/scripts/DialogueSystem/dialogues , et leur nom de fichier doit etre le même que le nom de classe.
/// ex: le fichier Assets/scripts/DialogueSystem/dialogues/Df_Bonjour.cs contient la classe " Df_Bonjour : DialogueFlow "
/// </summary>
[Serializable]
public abstract class DialogueFlow 
{
    protected DialoguePanel _panel;
    protected DialogueCharacters _characters;
    protected MonoBehaviour WorldObject;
    // Start is called before the first frame update
    public DialogueFlow(DialoguePanel panel, DialogueCharacters characters,MonoBehaviour _WorldObject)
    {
        this.WorldObject = _WorldObject;
        _panel = panel;
        _characters = characters;
        characters.initAllCharacters(this, panel);
    }

    public virtual async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Nestor, _characters.Noah);

        _characters.Nestor.SetEmotion(DialogueCharacter.Emotions.Normal);
        await _characters.Nestor.Say("Ta pute la mère noire oui c'est la mère noire yodelyodeliyodel ma grosse raclette la poésie putain");
        
        await _characters.Noah.Say("ouh là là ça fait mal ça aie aie aie caramba baba my world is upside down; cold sleep il all I found");
        await _characters.Nestor.Say("All because of you, I haven't slept for so long. When I do I dream, I'm drowning in the ocean, longing for a shore, where I could let my head rest inside those arms of yours");
    }

}

/*  ===========================  EXEMPLE  ===========================================

public class DialogueTest_1 : DialogueFlow
{

    public DialogueTest_1(DialoguePanel panel, DialogueCharacters characters): base(panel, characters) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Nestor, _characters.Noah);

        await _characters.Nestor.Say("Ta pute la mère noire oui c'est la mère noire yodelyodeliyodel ma grosse raclette la poésie putain");
        await _characters.Noah.Say("ouh là là ça fait mal ça aie aie aie caramba baba my world is upside down; cold sleep il all I found");
        await _characters.Nestor.Say("All because of you, I haven't slept for so long. When I do I dream, I'm drowning in the ocean, longing for a shore, where I could let my head rest inside those arms of yours");
    }
}

*/
