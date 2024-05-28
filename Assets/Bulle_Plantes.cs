using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulle_Plantes : MonoBehaviour
{
    public static int count = 0;
    public bool spawnBubbleWhenPlayerIsNear = false;

    [SerializeField] Bulle bubblePrefab;
    [SerializeField] int id;
    [SerializeField] PlantMain plantMain;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(t());
        
    }

    private IEnumerator t()
    {
        if(count<=5)
        yield return new WaitForSeconds(3);
        else
        yield return new WaitForSeconds(8);


        if (/*count < 6*/plantMain.CanWater  && spawnBubbleWhenPlayerIsNear)
        {
            spawnBubbleWhenPlayerIsNear = false;
            count++;

            Instantiate(bubblePrefab).setUp(id, gameObject, Vector3.up * 3);

        }
    }

}
