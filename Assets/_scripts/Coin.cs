using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _radius;

    private void Update()
    {
        FindPlayer();
    }
    private void FindPlayer()
    {
        Collider[] CoinColl = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider col in CoinColl)
        {
            if (col.CompareTag("Player"))
            {
                transform.position = Vector3.MoveTowards(transform.position, col.transform.position, Time.deltaTime * 5f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
