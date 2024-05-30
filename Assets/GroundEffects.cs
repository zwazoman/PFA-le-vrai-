using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//https://johnleonardfrench.com/terrain-footsteps-in-unity-how-to-detect-different-textures/
public class GroundEffect : MonoBehaviour
{
    public Transform playerTransform;
    public Terrain t;
    public int posX;
    public int posZ;
    public float[] textureValues = new float[2];
    public UnityEvent OnTextureInfoUpdated;

    void Start()
    {
        t = Terrain.activeTerrain;
        playerTransform = gameObject.transform;
        
        /*for (int i = 0; i < t.terrainData.detailWidth; i++)
        {
            for (int j = 0; j < t.terrainData.detailHeight; j++)
            {
                if (j == 0) yield return 0;
                if (Map[i, j] != 0)
                {
                    Debug.Log(i + "," + j + "	" + Map[i, j]);
                }
                    
                
            }
        }*/

    }

    //à appeler à chaque pas
    public void computeTextureValues()
    {
        GetTerrainTexture();
        OnTextureInfoUpdated.Invoke();
    }


    public void GetTerrainTexture()
    {
        ConvertPosition(playerTransform.position);
        CheckTexture();
    }
    void ConvertPosition(Vector3 playerPosition)
    {
        Vector3 terrainPosition = playerPosition - t.transform.position;
        Vector3 mapPosition = new Vector3
        (terrainPosition.x / t.terrainData.size.x, 0,
        terrainPosition.z / t.terrainData.size.z);
        float xCoord = mapPosition.x * t.terrainData.alphamapWidth;
        float zCoord = mapPosition.z * t.terrainData.alphamapHeight;
        posX = (int)xCoord;
        posZ = (int)zCoord;
    }
    void CheckTexture()
    {
        float[,,] aMap = t.terrainData.GetAlphamaps(posX, posZ, 1, 1);

        textureValues[0] = aMap[0, 0, 1];
        textureValues[1] = aMap[0, 0, 1];
    }
}