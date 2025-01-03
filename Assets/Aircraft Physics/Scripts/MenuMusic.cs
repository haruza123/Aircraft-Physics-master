using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private static MenuMusic instance;

    void Awake()
    {
        // Pastikan hanya ada satu instance musik
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Jangan hancurkan GameObject saat ganti scene
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

