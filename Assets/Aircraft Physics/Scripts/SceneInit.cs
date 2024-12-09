using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInit : MonoBehaviour
{

    public GameObject[] aircrafts;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(aircrafts[PlayerPrefs.GetInt("SelectedAircraft", 0)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
