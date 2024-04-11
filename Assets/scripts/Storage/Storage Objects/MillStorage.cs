using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillStorage : Storage
{
    public int MillMoney { get; private set; }
    protected override bool CanAbsorb(Item item)
    {
        return item.GetType() == typeof(Orb);
    }

    protected override void OnAbsorb(GameObject item)
    {
        MillMoney += item.GetComponent<Orb>().OrbValue;
        Destroy(item);
        print(MillMoney);
    }
}
