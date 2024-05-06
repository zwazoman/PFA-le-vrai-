using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyFlask : Breakable
{
    [SerializeField] private float _range;
    [SerializeField] private float _reduceAmount;

    private Collider[] _hitColliders;

    public override void Break()
    {
        //instancier vfx
        _hitColliders = Physics.OverlapSphere(transform.position, _range);
        foreach(Collider hitCollider in _hitColliders)
        {
            if(hitCollider.gameObject.TryGetComponent<PlantMain>(out PlantMain main))
            {
                main.Corruption.ReduceCorruption(_reduceAmount);
            }
        }
        base.Break();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
