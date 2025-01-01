using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SunMovement : MonoBehaviour
{
    public float transitionDuration = 240f;  // Durasi transisi (1 menit)
    public Material skyboxSiang;           // Skybox siang
    public Material skyboxSore;            // Skybox sore
    public Light sunLight;                 // Objek matahari (Directional Light)

    private float rotationSpeed;
    private float transitionTimer = 0f;
    private bool isTransitioning = true;

    void Start()
    {
        // Set Skybox awal ke siang
        RenderSettings.skybox = skyboxSiang;

        // Hitung rotasi kecepatan berdasarkan durasi (90 derajat dalam 1 menit)
        rotationSpeed = 90f / transitionDuration;
    }

    void Update()
    {
        if (isTransitioning)
        {
            // Hitung waktu transisi
            transitionTimer += Time.deltaTime;

            // Mulai transisi dari siang ke sore
            float lerpFactor = Mathf.Clamp01(transitionTimer / transitionDuration);

            // Interpolasi Skybox
            RenderSettings.skybox.Lerp(skyboxSiang, skyboxSore, lerpFactor);

            // Rotasi matahari mengikuti waktu transisi
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);

            // Sesuaikan intensitas cahaya matahari (lebih redup saat sore)
            if (sunLight != null)
            {
                sunLight.intensity = Mathf.Lerp(1.0f, 0.5f, lerpFactor);
                sunLight.color = Color.Lerp(Color.white, new Color(1f, 0.6f, 0.4f), lerpFactor); // Dari putih ke oranye
            }

            // Hentikan transisi setelah selesai
            if (transitionTimer >= transitionDuration)
            {
                isTransitioning = false;  // Stop transisi
            }
        }
    }
}
