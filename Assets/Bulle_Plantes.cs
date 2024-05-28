using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulle_Plantes : MonoBehaviour
{
    public static int count = 0;
    public bool spawnBubbleWhenPlayerIsNear = false;

    [SerializeField] Bulle bubblePrefab;
    [SerializeField] int id;

    private void OnTriggerEnter(Collider other)
    {
        if(count<6 && spawnBubbleWhenPlayerIsNear)
        {
            spawnBubbleWhenPlayerIsNear=false;
            count++;

            Instantiate(bubblePrefab).setUp(id,gameObject,Vector3.up*3);

        }
    }

}
