using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public WaterWheel waterWheel;

    public AudioClip song;
    public int bpm;

    AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();

        waterWheel.SetBeatsPerMinute(bpm);
        waterWheel.SetAudioSource(audioSource);
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyUp(KeyCode.Alpha1) && !audioSource.isPlaying)
        {
            waterWheel.StartRotate();
            audioSource.Play(0);
        }
	}
}
