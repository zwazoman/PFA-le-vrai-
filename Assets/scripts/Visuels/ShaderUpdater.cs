using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ShaderUpdater : MonoBehaviour
{
    [SerializeField] Material _shader;
    void Update()
    {
        _shader.SetVector("_PlayerPosition",transform.position);
    }
}
