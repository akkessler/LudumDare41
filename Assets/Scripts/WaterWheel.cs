using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWheel : MonoBehaviour {

    public const int NUM_SEGMENTS = 16;

    public float beatsPerMinute = 60;

    float revolutionsPerMinute;
    float degreesPerMinute;
    float degreesPerSecond;

    bool isRotating;

    // Use this for initialization
    void Start ()
    {
        revolutionsPerMinute = beatsPerMinute / NUM_SEGMENTS;
        degreesPerMinute = revolutionsPerMinute * 360;
        degreesPerSecond = degreesPerMinute / 60f;
        isRotating = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            isRotating = !isRotating;
        }
        if (isRotating)
        {
            transform.Rotate(Vector3.back * degreesPerSecond * Time.deltaTime, Space.Self);
        }
    }
}
