using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform bulletHolePrefab;

    public float weaponRange = 1000f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            // TODO Play gun blast sound

            Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, weaponRange))
            {
                // TODO Use object pooling for bullet holes.
                Target t = hit.transform.GetComponent<Target>();
                if (t != null)
                {
                    Vector3 pos = t.transform.position + (-t.transform.forward * .05f);
                    Transform bulletHole = Instantiate(bulletHolePrefab, hit.point + (hit.normal * .005f), Quaternion.FromToRotation(Vector3.up, hit.normal));
                    bulletHole.transform.parent = hit.transform.parent; // parent for scales to work on water wheel?
                    t.SendMessage("TakeDamage");
                    return;
                }
                else
                {
                    // TODO Any other logic for when you miss a shot
                    ScoreKeeper.instance.EndStreak();
                }


                WaterWheel w = hit.transform.GetComponent<WaterWheel>();
                if (w != null)
                {
                    Vector3 pos = w.transform.position + (-w.transform.forward * .05f);
                    Transform bulletHole = Instantiate(bulletHolePrefab, hit.point + (hit.normal * .005f), Quaternion.FromToRotation(Vector3.up, hit.normal));
                    bulletHole.transform.parent = hit.transform;
                    return;
                }


            }
        }
    }
}
