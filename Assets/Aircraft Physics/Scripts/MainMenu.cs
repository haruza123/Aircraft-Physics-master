using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int idx)  
    {
        PlayerPrefs.SetInt("SelectedAircraft", idx); // Simpan indeks pesawat
        Debug.Log("Selected Aircraft Index set to: " + idx); // Debug untuk memastikan nilai benar
        SceneManager.LoadSceneAsync("Flight"); // Ganti dengan nama scene Anda
    }
}
