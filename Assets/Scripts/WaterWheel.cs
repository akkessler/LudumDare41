using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWheel : MonoBehaviour {

    public const int NUM_SEGMENTS = 16;

    public float beatsPerMinute;

    float revolutionsPerMinute;
    float degreesPerMinute;
    float degreesPerSecond;

    public bool isRotating
    {
        get;
        private set;
    }

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
        if (isRotating)
        {
            transform.Rotate(Vector3.back * degreesPerSecond * Time.deltaTime, Space.Self);
        }
    }

    public void StartRotate()
    {
        isRotating = true;
    }

    public void StopRotate()
    {
        isRotating = false;
    }

    public void SetBeatsPerMinute(int beatsPerMinute)
    {
        this.beatsPerMinute = beatsPerMinute;
    }
}
