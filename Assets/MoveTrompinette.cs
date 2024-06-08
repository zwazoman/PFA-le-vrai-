using System.Collections;
using UnityEngine;

public class MoveTrompinette : MonoBehaviour
{
    [SerializeField] float vitesse;

    private void Start() => StartCoroutine(DestructorOfTrompinette());
  
    void Update()
    {
        gameObject.transform.Translate(Vector3.right * vitesse * Time.deltaTime);
    }

    IEnumerator DestructorOfTrompinette()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
