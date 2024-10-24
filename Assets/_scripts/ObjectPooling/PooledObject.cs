using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ce component permet � un objet de se souvenir de la pool de laquelle il vient, ainsi que de son index dedans.
/// il a �galement une m�thode pour d�sactiver l'objet et le renvoyer dans la pool.
/// </summary>
public class PooledObject : MonoBehaviour
{
    //ces variables sont g�r�es automatiquement par la pool � laquelle appartient l'objet.
    public bool IsInPool = true;
    public int Index;
    public Pool Pool;

    public Component mainComponent;

    public Component fetchMainComponent<T>() where T : Component
    {
        if(mainComponent == null)
        mainComponent = GetComponent<T>();

        return mainComponent;
    }


    /// <summary>
    /// � utiliser � la place de Destroy(gameObject)
    /// </summary>
    public void GoBackIntoPool()
    {
        if(!IsInPool) Pool.PutObjectBackInPool(this);
    }

}
