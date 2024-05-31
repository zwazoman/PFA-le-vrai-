using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flecheTriggerDeCon : MonoBehaviour
{
    public fleche f;
    [SerializeField] public Sprite sprite;// { get; private set; }
    [SerializeField] public Transform target;// { get; private set; }
    [SerializeField] public int Priority;// {  get ;private set; }

    public bool CancelFleche = false;
    private void Start()
    {
        f = fleche.instance;
    }

    public void TryToTriggerFleche()
    {
        f.SetUp(this);
    }

    public void Cancel()
    {
        if(f.currentTarget == this)
        {
            f.SetUp(null);
        }
    }
}
