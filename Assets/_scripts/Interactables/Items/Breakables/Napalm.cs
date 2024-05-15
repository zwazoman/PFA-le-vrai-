using UnityEngine;

public class Napalm : Breakable
{
    [SerializeField] private float _range;
    [SerializeField] private float _increaseAmount;

    private Collider[] _hitColliders;

    private void Awake()
    {
        maxhp = 1;
    }
    protected override void Break()
    {
        //instancier vfx
        _hitColliders = Physics.OverlapSphere(transform.position, _range);
        foreach (Collider hitCollider in _hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<PlantMain>(out PlantMain main))
            {
                main.Unplant();
            }
        }
        base.Break();
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _range);
    }*/
}
