using UnityEngine;

/// <summary>
/// orb lach�e par les boutures d'�mes lors de la r�colte. H�ritage 
/// </summary>
public class Orb : Item
{
    [field : SerializeField]
    public int OrbValue { get; private set; }

    private void Start()
    {
        Jump();
    }
}
