using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTrees : MonoBehaviour
{
    public Terrain terrain;
    public GameObject treePrefab;
    public int treeCount = 100; // Jumlah pohon

    void Start()
    {
        PlantTrees();
    }

    void PlantTrees()
    {
        TerrainData terrainData = terrain.terrainData;

        for (int i = 0; i < treeCount; i++)
        {
            float x = Random.Range(0, terrainData.size.x);
            float z = Random.Range(0, terrainData.size.z);
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrain.transform.position.y;

            Vector3 position = new Vector3(x, y, z);
            Instantiate(treePrefab, position, Quaternion.identity);
        }
    }
}
