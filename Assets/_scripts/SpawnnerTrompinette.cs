using System.Collections;
using UnityEngine;

public class SpawnnerTrompinette : MonoBehaviour
{
    [SerializeField] float xCo, zCo;
    [SerializeField] GameObject _trompinette;
    void Start()
    {
        StartCoroutine(SpawnTrompinette());
    }
    IEnumerator SpawnTrompinette()
    {
        while (true) 
        {
            Instantiate(_trompinette, transform.position = new Vector3(xCo, Random.Range(3, 21), zCo) , transform.rotation);
            yield return new WaitForSeconds(Random.Range(1, 4)); 
        }
    }
}
