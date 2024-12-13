using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTreePlacer : MonoBehaviour
{
    public Terrain terrain;
    public GameObject treePrefab;
    public int treeCount = 1000;

    void Start()
    {
        PlaceTrees();
    }

    void PlaceTrees()
    {
        TerrainData terrainData = terrain.terrainData;

        for (int i = 0; i < treeCount; i++)
        {
            float x = Random.Range(0, terrainData.size.x);
            float z = Random.Range(0, terrainData.size.z);
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrain.transform.position.y;

            // Cek kemiringan tanah
            float slope = terrainData.GetSteepness(x / terrainData.size.x, z / terrainData.size.z);
            if (slope < 30) // Pohon hanya ditanam di area dengan kemiringan kurang dari 30 derajat
            {
                Instantiate(treePrefab, new Vector3(x, y, z), Quaternion.identity);
            }
        }
    }
}

