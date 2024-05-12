using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ShaderUpdater : MonoBehaviour
{
    [SerializeField]List< Material > materials;
    void Update()
    {
        foreach(Material mat in materials)
        mat.SetVector("_PlayerPosition",transform.position);
    }

    private void OnApplicationQuit()
    {
        foreach (Material mat in materials)  mat.SetVector("_PlayerPosition", Vector3.zero);
    }
}
