using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralCity : MonoBehaviour
{
    public GameObject buildingPrefab;
    public int buildingCount = 50; // Jumlah bangunan
    public Vector2 cityArea = new Vector2(100, 100); // Area kota

    void Start()
    {
        GenerateCity();
    }

    void GenerateCity()
    {
        for (int i = 0; i < buildingCount; i++)
        {
            float x = Random.Range(-cityArea.x / 2, cityArea.x / 2);
            float z = Random.Range(-cityArea.y / 2, cityArea.y / 2);
            float y = 0; // Bangunan di ground level

            Instantiate(buildingPrefab, new Vector3(x, y, z), Quaternion.identity);
        }
    }
}

