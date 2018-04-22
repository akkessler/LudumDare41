using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public bool inTargetZone;
    public bool wasShotInTargetZone;

    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Use this for initialization
    void Start () {
        meshRenderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetState()
    {
        inTargetZone = false;
        wasShotInTargetZone = false;
    }

    // TODO Better visual effects for when in zone.
    public void EnterTargetZone()
    {
        inTargetZone = true;
        meshRenderer.material.color = Color.green;
    }

    public void ExitTargetZone()
    {
        inTargetZone = false;
        meshRenderer.material.color = Color.red;
    }

    public void TakeDamage()
    {
        if(inTargetZone)
        {
            wasShotInTargetZone = true;
            ScoreKeeper.instance.IncreaseStreakAndPoints(1);
        }
        else
        {
            ScoreKeeper.instance.EndStreak();
        }
        // TODO Play a sound (steel hit sound)
    }

}
