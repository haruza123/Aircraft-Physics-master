﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileAirplaneController : MonoBehaviour
{

    public Slider slider;
    public Slider brakeSlider;

    public float verticalInput;
    public float horizontalInput;
    public float yawInput;
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

    public void SetVertical(float val){
        verticalInput = val;
    }
    public void SetHorizontal(float val){
        horizontalInput = val;
    }
    public void SetYaw(float val){
        yawInput = val;
    }
}
