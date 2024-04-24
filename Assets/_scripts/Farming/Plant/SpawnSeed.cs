using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSeed : Interactable
{
    [SerializeField] GameObject seedPrefab;
    [SerializeField] float seedAmount;


    protected override void Interaction()
    {
       // if (!_canInteract) return;
        //_canInteract = false;
        StartCoroutine(ThrowSeed());
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
        for(int i = 0; i <= seedAmount; i++)
        {
            Instantiate(seedPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        }

    }
}
