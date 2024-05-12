using UnityEngine;

/// <summary>
/// parent des outils du joueur. Le script sera appelé chauqe fois que le joueur utilise un outil pour déterminer sa portée et sa longueur
/// </summary>
public abstract class Tool : MonoBehaviour
{
    [field : SerializeField]
    protected float ToolLength { get; private set; }
    [field : SerializeField]
    protected float ToolRange { get; private set; }

    protected Collider[] hitColliders { get; private set; }

    /// <summary>
    /// vérifie si un objet se trouve devant le joueur
    /// </summary>
    public virtual void Use() 
    {
        hitColliders = Physics.OverlapSphere(transform.position + transform.forward * ToolLength, ToolRange);
    }
    /*
    /// <summary>
    /// dessine la portée et longueur des outils
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + transform.forward * ToolLength, ToolRange);
    }
    */
}
