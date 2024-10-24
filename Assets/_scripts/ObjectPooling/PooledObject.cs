using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ce component permet à un objet de se souvenir de la pool de laquelle il vient, ainsi que de son index dedans.
/// il a également une méthode pour désactiver l'objet et le renvoyer dans la pool.
/// </summary>
public class PooledObject : MonoBehaviour
{
    //ces variables sont gérées automatiquement par la pool à laquelle appartient l'objet.
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
    /// à utiliser à la place de Destroy(gameObject)
    /// </summary>
    public void GoBackIntoPool()
    {
        if(!IsInPool) Pool.PutObjectBackInPool(this);
    }

}
