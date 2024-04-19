using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillStorage : Storage
{
    public int MillMoney { get;  set; }
    protected override bool CanAbsorb(Item item)
    {
        return item.GetType() == typeof(Orb);
    }

    protected override void OnAbsorb(GameObject orb)
    {
        MillMoney += orb.GetComponent<Orb>().OrbValue;
        Destroy(orb);
        print(MillMoney);
    }
}
