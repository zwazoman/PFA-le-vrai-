using System.Collections;
using UnityEngine;

public class SpawnSeed : Interactable
{
    [SerializeField] GameObject _seedPrefab;


    protected override void Interaction()
    {
       // if (!_canInteract) return;
        //_canInteract = false;

        StartCoroutine(ThrowSeed());
        PlayerMain.Instance.Stats.Seeds = PlayerMain.Instance.Stats.InitialSeeds;

    }


   /* private void Start()
    {
        TimeManager.Instance.OnHour += SetGoodSpawnTime;
    }*/

   /* private void SetGoodSpawnTime()
    {
        if (TimeManager.Instance.Hour == 10) _canInteract = true;
    }*/

    private IEnumerator ThrowSeed()
    {
        for(int i = 0; i <= PlayerMain.Instance.Stats.Seeds; i++)
        {
            Instantiate(_seedPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        }
    }
}
