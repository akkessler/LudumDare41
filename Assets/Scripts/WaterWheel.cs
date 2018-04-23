using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWheel : MonoBehaviour {

    public const int NUM_SEGMENTS = 16;

    public float beatsPerMinute;

    float revolutionsPerMinute;
    float degreesPerMinute;
    float degreesPerSecond;
    AudioSource audioSource;
    float prevSongTime;

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
            float currSongTime = audioSource.time;
            float deltaSongTime = currSongTime - prevSongTime;
            prevSongTime = currSongTime;

            transform.Rotate(Vector3.back * degreesPerSecond * deltaSongTime, Space.Self);
        }
    }

    public void StartRotate()
    {
        isRotating = true;
        prevSongTime = audioSource.time;
    }

    public void StopRotate()
    {
        isRotating = false;
    }

    public void SetBeatsPerMinute(int beatsPerMinute)
    {
        this.beatsPerMinute = beatsPerMinute;
    }

    public void SetAudioSource(AudioSource audioSource)
    {
        this.audioSource = audioSource;
    }
}
