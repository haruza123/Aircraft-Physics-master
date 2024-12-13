using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralCityPlacer : MonoBehaviour
{
    public Terrain terrain;
    public GameObject buildingPrefab;
    public int buildingCount = 100;

    void Start()
    {
        PlaceBuildings();
    }

    void PlaceBuildings()
    {
        TerrainData terrainData = terrain.terrainData;

        for (int i = 0; i < buildingCount; i++)
        {
            float x = Random.Range(0, terrainData.size.x);
            float z = Random.Range(0, terrainData.size.z);
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrain.transform.position.y;

            // Cek kemiringan tanah
            float slope = terrainData.GetSteepness(x / terrainData.size.x, z / terrainData.size.z);
            if (slope < 10) // Bangunan hanya diletakkan di area datar
            {
                Instantiate(buildingPrefab, new Vector3(x, y, z), Quaternion.identity);
            }
        }
    }
}

