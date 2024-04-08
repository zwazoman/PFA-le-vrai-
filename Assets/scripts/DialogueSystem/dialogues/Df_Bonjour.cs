using System.Threading.Tasks;

public class Df_Bonjour : DialogueFlow
{
    public Df_Bonjour(DialoguePanel panel, DialogueCharacters characters) : base(panel, characters) { }

    public override async Task StartDialogue()
    {
        _panel.InitDialogue(_characters.Nestor, _characters.Noah);

        await _characters.Nestor.Say("OH PUTAIN CA MARCHE");
        await _characters.Noah.Say("NATHAN LE GOAT");
        await _characters.Nestor.Say("CEST SI BEAU");
    }
}
