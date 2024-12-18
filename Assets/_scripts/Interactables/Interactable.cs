using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
/// <summary>
/// permet au joueur d'intéragir avec l'objet
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    public void InteractWith()
    {
        OnStopHighLight();
        Interaction();
        //PlayerMain.Instance.Interaction.Interactables.Clear();
    }
    
    protected abstract void Interaction();

    List<GameObject> outlineMeshes = new();

    public void OnHighlighted()
    {

        foreach(MeshFilter mr in GetComponentsInChildren<MeshFilter>())
        {
            if (mr.gameObject.GetComponent<MeshRenderer>().enabled && mr.gameObject.activeSelf)
            {
                GameObject spawned = GameObject.Instantiate(Resources.Load<GameObject>("OutlineMesh"), mr.gameObject.transform);
                /*spawned.transform.localScale = Vector3.one;
                spawned.transform.localPosition = Vector3.zero;
                spawned.transform.localRotation = Quaternion.identity;*/

                spawned.GetComponent<MeshFilter>().sharedMesh = mr.sharedMesh;
                outlineMeshes.Add(spawned);
            } 
            
        }
    }

    public void OnStopHighLight()
    {

        foreach(GameObject Mesh in outlineMeshes)
        {
            Destroy(Mesh);
        }
        outlineMeshes.Clear();
    }

    protected virtual void OnDestroy()
    {
        if(PlayerMain.Instance!=null) PlayerMain.Instance.GrabBox.ClearHands();
    }
}
