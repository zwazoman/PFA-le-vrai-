using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Charon : Interactable
{
    [SerializeField] string _dialogue;
    [SerializeField] List<GameObject> _seedPrefabs;
    [SerializeField] public Transform SpawnSocket;
    [SerializeField] charon_bateau bateau;
    protected override void Interaction()
    {
        activateDialogue();
    }

    async void activateDialogue()
    {
        GetComponent<Collider>().enabled = false;
        PlayerMain.Instance.Interaction.Interactables.Clear();
        await UiManager.Instance.PopupDialogue(_dialogue,this);

        //TimeManager.Instance.pauseTime();
        for (int i = 0; i <= PlayerMain.Instance.Stats.Seeds + Random.Range(-1,2); i++)
        {
            int rand = Random.Range(0,2);
            if(rand == 0) PlayerMain.Instance.Sounds.PlayDropPopSound(); else PlayerMain.Instance.Sounds.PlayPickupPopSound();
            Instantiate(_seedPrefabs[Random.Range(0, _seedPrefabs.Count)], SpawnSocket.position + Random.insideUnitSphere*0.5f , Quaternion.identity);
            await Task.Delay( Random.Range(200, 300));
        }
        //TimeManager.Instance.resume();
        bateau.Partir();

    }


}
