using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flecheTriggerDeCon : MonoBehaviour
{
    fleche f;
    [SerializeField] public Sprite sprite { get; private set; }
    [SerializeField] public Transform target { get; private set; }
    [SerializeField] public int Priority {  get ;private set; }
    private void Awake()
    {
        f = FindObjectOfType<fleche>();
    }

    public void TryToTriggerFleche()
    {
        f.SetUp(this);
    }
}
