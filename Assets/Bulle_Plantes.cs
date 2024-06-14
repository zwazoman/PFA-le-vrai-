using System.Collections;
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
        yield return new WaitForSeconds(7);
        else
        yield return new WaitForSeconds(12);


        if (/*count < 6*/plantMain.CanWater  && spawnBubbleWhenPlayerIsNear && ! plantMain.Harvest.isHarvesteable)
        {
            spawnBubbleWhenPlayerIsNear = false;
            count++;

            Instantiate(bubblePrefab).setUp(id, gameObject, Vector3.up * 3);

        }
    }

}
