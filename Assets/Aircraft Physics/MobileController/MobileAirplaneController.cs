using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileAirplaneController : MonoBehaviour
{

    public Slider slider;
    public Slider brakeSlider;

    public static MobileAirplaneController instance;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
