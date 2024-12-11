using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTerrain : MonoBehaviour
{
    public int width = 512; // Lebar terrain
    public int height = 512; // Panjang terrain
    public int depth = 50; // Tinggi terrain
    public float scale = 20f; // Skala Perlin Noise
    public Terrain terrain;

    void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        TerrainData terrainData = terrain.terrainData;
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                heights[x, z] = CalculateHeight(x, z);
            }
        }
        return heights;
    }

    float CalculateHeight(int x, int z)
    {
        float xCoord = (float)x / width * scale;
        float zCoord = (float)z / height * scale;

        return Mathf.PerlinNoise(xCoord, zCoord); // Hasil Perlin Noise
    }
}


