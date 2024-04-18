using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSeed : MonoBehaviour
{
    [SerializeField] GameObject seedPrefab;
    [SerializeField] float seedAmount;

    private void Start()
    {
       TimeManager.Instance.OnHour += () => StartCoroutine( ThrowSeed());
    }

    private IEnumerator ThrowSeed()
    {
        if ((transform.position - PlayerMain.Instance.transform.position).sqrMagnitude > 35 * 35) yield break;

            if (TimeManager.Instance.Hour != 10) yield break;
        for(int i = 0; i <= seedAmount; i++)
        {
            Instantiate(seedPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        }
    }
}
