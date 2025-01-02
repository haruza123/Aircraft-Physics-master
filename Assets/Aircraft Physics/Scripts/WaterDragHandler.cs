using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AircraftPhysics))]

public class WaterResistanceController : MonoBehaviour
{
    private AircraftPhysics aircraftPhysics; // Referensi ke script utama
    private bool inWater = false;
    private float originalThrustPercent;

    [SerializeField]
    [Range(0f, 1f)] 
    private float waterThrustMultiplier = 0.5f; // Persentase thrust saat di air (50%)

    private void Start()
    {
        aircraftPhysics = GetComponent<AircraftPhysics>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water")) // Pastikan collider air memiliki tag "Water"
        {
            inWater = true;
            originalThrustPercent = GetThrustPercent(); // Simpan thrust asli
            aircraftPhysics.SetThrustPercent(originalThrustPercent * waterThrustMultiplier);
            Debug.Log("Pesawat memasuki air. Thrust dikurangi.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            inWater = false;
            aircraftPhysics.SetThrustPercent(originalThrustPercent); // Kembalikan thrust asli
            Debug.Log("Pesawat keluar dari air. Thrust kembali normal.");
        }
    }

    private float GetThrustPercent()
    {
        // Mengambil thrustPercent dari AircraftPhysics (jika dibuat public)
        var thrustPercentField = typeof(AircraftPhysics).GetField("thrustPercent", 
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        return thrustPercentField != null ? (float)thrustPercentField.GetValue(aircraftPhysics) : 1f;
    }
}

