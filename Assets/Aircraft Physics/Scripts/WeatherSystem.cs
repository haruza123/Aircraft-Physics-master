using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSystem : MonoBehaviour
{
    public enum WeatherType { Clear, Rain, Storm, Fog }
    public WeatherType currentWeather;

    public GameObject rainEffect; // Particle System untuk hujan

    public float windStrength = 0f; // Kekuatan angin
    public Vector3 windDirection = Vector3.zero; // Arah angin
    public float additionalWeight = 0f; // Berat tambahan ke pesawat
    public float weatherChangeInterval = 30f; // Waktu untuk mengganti cuaca (detik)

    private float timer;

    void Start()
    {
        SetRandomWeather(); // Atur cuaca pertama
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= weatherChangeInterval)
        {
            SetRandomWeather();
            timer = 0f;
        }
    }

    void SetRandomWeather()
    {
        currentWeather = (WeatherType)Random.Range(0, System.Enum.GetValues(typeof(WeatherType)).Length);
        Debug.Log("Current Weather: " + currentWeather);

        // Atur efek berdasarkan cuaca
        switch (currentWeather)
        {
            case WeatherType.Clear:
                rainEffect.SetActive(false); // Nonaktifkan hujan
                windStrength = 0f;
                windDirection = Vector3.zero;
                additionalWeight = 0f;
                break;

            case WeatherType.Rain:
                rainEffect.SetActive(true); // Aktifkan hujan
                windStrength = Random.Range(5f, 10f); // Angin ringan
                windDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
                additionalWeight = 500f; // Berat tambahan karena air
                break;

            case WeatherType.Storm:
                rainEffect.SetActive(true); // Aktifkan hujan
                windStrength = Random.Range(15f, 25f); // Angin kuat
                windDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
                additionalWeight = 1000f; // Berat tambahan karena badai
                break;

            case WeatherType.Fog:
                rainEffect.SetActive(false); // Nonaktifkan hujan
                windStrength = Random.Range(2f, 5f); // Angin sangat ringan
                windDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
                additionalWeight = 0f; // Tidak ada tambahan berat
                break;
        }
    }
}



