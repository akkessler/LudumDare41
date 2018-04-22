using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Target t = other.GetComponent<Target>();
        if(t != null)
        {
            t.EnterTargetZone();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Target t = other.GetComponent<Target>();
        if (t != null)
        {
            t.ExitTargetZone();
            if(!t.wasShotInTargetZone)
            {
                ScoreKeeper.instance.EndStreak();
            }
        }
    }
}
