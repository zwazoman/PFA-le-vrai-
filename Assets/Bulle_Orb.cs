using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulle_Orb : MonoBehaviour
{
    public static bool alreadyHappened;
    [SerializeField] int image;
    [SerializeField] private Bulle bullePrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (!alreadyHappened && Time.time>1)
        {
            Instantiate(bullePrefab, transform ).setUp(image,gameObject,Vector3.up);
            alreadyHappened = true;
        }
        Destroy(this);
    }

}
