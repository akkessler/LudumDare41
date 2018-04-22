using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWheel : MonoBehaviour {

    public float rotationSpeed = 42f;
    public bool isRotating = false;

	// Use this for initialization
	void Start ()
    {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            isRotating = !isRotating;
        }
        if (isRotating)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed, Space.Self);
        }
    }
}
