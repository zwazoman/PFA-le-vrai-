using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Charon : Interactable
{
    [SerializeField] string _dialogueGraines;
    [SerializeField] string _dialogueAttente;
    [SerializeField] List<GameObject> _seedPrefabs;
    [SerializeField] public Transform SpawnSocket;
    [SerializeField] charon_bateau bateau;

    public bool AlreadyUsed = false;
    protected override void Interaction()
    {
        if (!AlreadyUsed)
        {
            activateDialogue();
            QuestManager.Instance.TryProgressQuest("SeedDelivery", 1);
            AlreadyUsed = true;
        }
        else
        {
            _ = UiManager.Instance.PopupDialogue(_dialogueAttente, this);
        }
        
    }

    async void activateDialogue()
    {
        /*GetComponent<Collider>().enabled = false;
        PlayerMain.Instance.Interaction.Interactables.Clear();*/
        await UiManager.Instance.PopupDialogue(_dialogueGraines, this);

        //TimeManager.Instance.pauseTime();
        for (int i = 0; i <= PlayerMain.Instance.Stats.Seeds + Random.Range(-1,2); i++)
        {
            //son
            if(Random.Range(0, 2) == 0) PlayerMain.Instance.Sounds.PlayDropPopSound(); else PlayerMain.Instance.Sounds.PlayPickupPopSound();

            //spawn seed
            Instantiate(_seedPrefabs[Random.Range(0, _seedPrefabs.Count)], SpawnSocket.position + Random.insideUnitSphere*0.5f , Quaternion.identity);
            await Task.Delay( Random.Range(200, 300));
        }

    }


}
