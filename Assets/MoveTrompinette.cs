using System.Collections;
using UnityEngine;

public class MoveTrompinette : MonoBehaviour
{
    [SerializeField] float vitesse;
    [SerializeField] AudioSource trompinetteSound;

    private void Start()
    {
        StartCoroutine(TrompinetteDestructor());
        if (Random.value < 1f / 15f) trompinetteSound.Play();
        trompinetteSound.pitch = Random.Range(0.7f, 1.7f);
                
    }
  
    void Update()
    {
        gameObject.transform.Translate(Vector3.right * vitesse * Time.deltaTime);
    }

    IEnumerator TrompinetteDestructor()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
