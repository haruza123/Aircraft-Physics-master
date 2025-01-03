using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Referensi panel UI
    public GameObject mainMenuPanel; // Panel untuk tombol Play dan Exit
    public GameObject aircraftSelectionPanel; // Panel untuk memilih pesawat
    public Transform previewHolder; // Tempat untuk menampilkan model pesawat
    public GameObject[] aircraftPrefabs; // Array prefab pesawat

    private GameObject currentPreview; // Untuk menyimpan model pesawat yang sedang ditampilkan
    private int currentIndex = 0; // Indeks pesawat yang sedang dipilih

    void Start()
    {
        // Hanya panel utama yang aktif di awal
        mainMenuPanel.SetActive(true);
        aircraftSelectionPanel.SetActive(false);
    }

    // Fungsi untuk tombol Play di Main Menu
    public void OnPlayButton()
    {
        // Aktifkan panel pemilihan pesawat dan nonaktifkan panel utama
        mainMenuPanel.SetActive(false);
        aircraftSelectionPanel.SetActive(true);

        // Tampilkan pesawat pertama sebagai default
        ShowAircraftPreview(currentIndex);
    }

    // Fungsi untuk tombol Exit
    public void OnExitButton()
    {
        Application.Quit(); // Keluar dari aplikasi
        Debug.Log("Game Closed"); // Debug untuk testing di editor
    }

    // Fungsi untuk tombol Play di Selector
    public void StartGame()
    {
        // Simpan pesawat yang sedang dipilih dan pindah ke scene Flight
        PlayerPrefs.SetInt("SelectedAircraft", currentIndex);
        Debug.Log("Selected Aircraft Index set to: " + currentIndex);

    GameObject music = GameObject.Find("MainMenuMusic");
    if (music != null)
    {
        Destroy(music); // Hancurkan musik saat pindah scene
    }


        SceneManager.LoadSceneAsync("Flight"); // Pindah ke scene simulasi
    }

    // Fungsi untuk menampilkan pesawat di preview
    public void ShowAircraftPreview(int aircraftIndex)
    {
        // Hapus model sebelumnya jika ada
        if (currentPreview != null)
        {
            Destroy(currentPreview);
        }

        // Pastikan index valid
        if (aircraftIndex >= 0 && aircraftIndex < aircraftPrefabs.Length)
        {
            currentPreview = Instantiate(aircraftPrefabs[aircraftIndex], previewHolder.position, Quaternion.identity, previewHolder);
            currentPreview.transform.localRotation = Quaternion.Euler(0, 180, 0); // Rotasi model (opsional)
        }
        AudioSource engineSound = currentPreview.GetComponentInChildren<AudioSource>();
        if (engineSound != null)
        {
            engineSound.enabled = false; // Nonaktifkan AudioSource
        }

    }

    // Fungsi untuk tombol Next (kanan)
    public void OnNextAircraft()
    {
        currentIndex = (currentIndex + 1) % aircraftPrefabs.Length; // Geser ke indeks berikutnya (loop)
        ShowAircraftPreview(currentIndex);
        Debug.Log("Current Aircraft Index: " + currentIndex);
    }

    // Fungsi untuk tombol Previous (kiri)
    public void OnPreviousAircraft()
    {
        currentIndex = (currentIndex - 1 + aircraftPrefabs.Length) % aircraftPrefabs.Length; // Geser ke indeks sebelumnya (loop)
        ShowAircraftPreview(currentIndex);
        Debug.Log("Current Aircraft Index: " + currentIndex);
    }
}

