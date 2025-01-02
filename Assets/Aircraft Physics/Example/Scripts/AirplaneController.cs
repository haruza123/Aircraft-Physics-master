using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirplaneController : MonoBehaviour
{
    [SerializeField]
    List<AeroSurface> controlSurfaces = null;
    [SerializeField]
    List<WheelCollider> wheels = null;
    [SerializeField]
    float rollControlSensitivity = 0.2f;
    [SerializeField]
    float pitchControlSensitivity = 0.2f;
    [SerializeField]
    float yawControlSensitivity = 0.2f;

    [Range(-1, 1)]
    public float Pitch;
    [Range(-1, 1)]
    public float Yaw;
    [Range(-1, 1)]
    public float Roll;
    [Range(0, 1)]
    public float Flap;
    [SerializeField]
    Text displayText = null;

    float thrustPercent;
    float brakesTorque;

    AircraftPhysics aircraftPhysics;
    Rigidbody rb;

    private void Start()
    {
        aircraftPhysics = GetComponent<AircraftPhysics>();
        rb = GetComponent<Rigidbody>();
        if (aircraftPhysics == null)
        {
            Debug.LogError("AircraftPhysics tidak ditemukan pada objek " + gameObject.name);
        }

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody tidak ditemukan pada objek " + gameObject.name);
        }
    }

    private void Update()
{
    if (MobileAirplaneController.instance == null)
    {
        Debug.LogError("MobileAirplaneController.instance is null! Pastikan MobileAirplaneController ada dan aktif di scene.");
        return; // Hentikan eksekusi untuk mencegah error lebih lanjut.
    }

    if (MobileAirplaneController.instance.slider == null || MobileAirplaneController.instance.brakeSlider == null)
    {
        Debug.LogError("Slider atau brakeSlider di MobileAirplaneController belum dihubungkan di Inspector!");
        return; // Hindari akses lebih lanjut jika slider tidak valid.
    }

    // Input dari Keyboard untuk Pitch, Roll, dan Yaw
    Pitch = Input.GetAxis("Vertical") + MobileAirplaneController.instance.verticalInput;
    Roll = Input.GetAxis("Horizontal") + MobileAirplaneController.instance.horizontalInput;
    Yaw = Input.GetAxis("Yaw") + MobileAirplaneController.instance.yawInput;

    // Kontrol thrust dengan tombol Space (menambah) dan LeftShift (mengurangi)
    if (Input.GetKeyDown(KeyCode.Space))
    {
        thrustPercent = Mathf.Clamp(thrustPercent + 0.1f, 0f, 1f); // Tambah thrust 10%
        MobileAirplaneController.instance.slider.value = thrustPercent; // Sinkronkan slider
    }
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
        thrustPercent = Mathf.Clamp(thrustPercent - 0.1f, 0f, 1f); // Kurangi thrust 10%
        MobileAirplaneController.instance.slider.value = thrustPercent; // Sinkronkan slider
    }

    // Kontrol brake dengan tombol B
    if (Input.GetKeyDown(KeyCode.B))
{
    // Toggle brake antara ON (1) dan OFF (0)
    brakesTorque = brakesTorque > 0 ? 0 : 100f;

    // Sinkronkan slider untuk mencerminkan nilai brake
    MobileAirplaneController.instance.brakeSlider.value = brakesTorque > 0 ? 1f : 0f;
}

    // Kontrol flap (sudah ada di kode Anda)
    if (Input.GetKeyDown(KeyCode.F))
    {
        Flap = Flap > 0 ? 0 : 0.3f;
    }

    // Input thrust dan brake dari slider (tetap berjalan)
    thrustPercent = MobileAirplaneController.instance.slider.value;
    brakesTorque = MobileAirplaneController.instance.brakeSlider.value > 0 ? 100f : 0f;

    // Tampilkan informasi ke UI
    displayText.text = "V: " + ((int)rb.velocity.magnitude).ToString("D3") + " m/s\n";
    displayText.text += "A: " + ((int)transform.position.y).ToString("D4") + " m\n";
    displayText.text += "T: " + (int)(thrustPercent * 100) + "%\n";
    displayText.text += brakesTorque > 0 ? "B: ON" : "B: OFF";
}


    private void FixedUpdate()
    {
        SetControlSurfecesAngles(Pitch, Roll, Yaw, Flap);
        aircraftPhysics.SetThrustPercent(thrustPercent);
        foreach (var wheel in wheels)
        {
            wheel.brakeTorque = brakesTorque;
            // small torque to wake up wheel collider
            wheel.motorTorque = 0.01f;
        }
    }

    public void SetControlSurfecesAngles(float pitch, float roll, float yaw, float flap)
    {
        foreach (var surface in controlSurfaces)
        {
            if (surface == null || !surface.IsControlSurface) continue;
            switch (surface.InputType)
            {
                case ControlInputType.Pitch:
                    surface.SetFlapAngle(pitch * pitchControlSensitivity * surface.InputMultiplyer);
                    break;
                case ControlInputType.Roll:
                    surface.SetFlapAngle(roll * rollControlSensitivity * surface.InputMultiplyer);
                    break;
                case ControlInputType.Yaw:
                    surface.SetFlapAngle(yaw * yawControlSensitivity * surface.InputMultiplyer);
                    break;
                case ControlInputType.Flap:
                    surface.SetFlapAngle(Flap * surface.InputMultiplyer);
                    break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
            SetControlSurfecesAngles(Pitch, Roll, Yaw, Flap);
    }
}
