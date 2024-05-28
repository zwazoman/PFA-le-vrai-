using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulle_Orb : MonoBehaviour
{
    public static int count;
    [SerializeField] int image;
    [SerializeField] private Bulle bullePrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (count<5 && Time.time>1)
        {
            Instantiate(bullePrefab, transform ).setUp(image,gameObject,Vector3.up);
            count++ ;
        }
        Destroy(this);
    }

}
