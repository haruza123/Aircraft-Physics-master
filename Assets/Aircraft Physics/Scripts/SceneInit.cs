using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInit : MonoBehaviour
{

    public GameObject[] aircrafts;
    private static bool isAircraftInstantiated = false;


    // Start is called before the first frame update
    void Start()
    {
        int selectedAircraft = PlayerPrefs.GetInt("SelectedAircraft", 0);
    Debug.Log("Selected Aircraft Index: " + selectedAircraft);
    Instantiate(aircrafts[selectedAircraft]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
