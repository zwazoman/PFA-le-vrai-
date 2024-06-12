using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trompinette : MonoBehaviour
{
    [SerializeField] AudioSource revEngine;

    public void OnPickUp()
    {
        revEngine.Play();
    }
}
