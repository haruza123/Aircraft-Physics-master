using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingZone : MonoBehaviour
{
    public GameObject landingCanvas; // Drag & drop LandingCanvas ke sini
    public FlightTimer flightTimer; // Tambahkan referensi ke FlightTimer

    void OnTriggerEnter(Collider other)
    {
        // Cek nama objek yang masuk trigger
        Debug.Log("Object Masuk Trigger: " + other.name);

        // Periksa apakah timer sudah selesai
        if (flightTimer != null && !flightTimer.IsTimerFinished)
        {
            Debug.Log("Timer belum selesai. Landing belum diizinkan.");
            return; // Jangan lanjutkan jika timer belum selesai
        }

        // Periksa apakah objek yang masuk memiliki parent dengan tag "Player"
        Transform rootObject = other.transform.root;
        if (rootObject.CompareTag("Player"))
        {
            Debug.Log("Pesawat berhasil mendarat!");

            // Aktifkan canvas untuk pesan landing
            if (landingCanvas != null)
            {
                landingCanvas.SetActive(true);
            }

            // Hentikan waktu di game
            Time.timeScale = 0;
        }
    }
}






