using UnityEngine;

public class Seed : Item
{
    [field : SerializeField]
    public GameObject Plant { get; private set; }

    private void Start()
    {
        Jump();
    }
}
