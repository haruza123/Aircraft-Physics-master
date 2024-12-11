using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftPreview : MonoBehaviour
{
    public GameObject[] aircraftModels; // Array model pesawat (Prefab)
    private GameObject currentModel; // Model yang sedang ditampilkan

    public void ShowAircraft(int index)
    {
        // Hapus model sebelumnya jika ada
        if (currentModel != null)
        {
            Destroy(currentModel);
        }

        // Instantiate model baru berdasarkan index
        if (index >= 0 && index < aircraftModels.Length)
        {
            currentModel = Instantiate(aircraftModels[index], transform.position, Quaternion.identity, transform);
        }
    }
}

