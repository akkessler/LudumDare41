﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetZone : MonoBehaviour {

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
