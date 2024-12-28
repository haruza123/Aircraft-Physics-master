using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingCanvasController : MonoBehaviour
{
    public void RestartGame()
    {
        // Atur TimeScale kembali normal
        Time.timeScale = 1;

        // Muat ulang scene saat ini
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        // Jika game berjalan di editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Jika game berjalan sebagai aplikasi
        Application.Quit();
        #endif
    }

    public void LoadMainMenu()
    {
        // Atur TimeScale kembali ke normal jika sebelumnya dihentikan
        Time.timeScale = 1;

        // Muat scene MainMenu
        SceneManager.LoadScene("MainMenu");
    }
}


