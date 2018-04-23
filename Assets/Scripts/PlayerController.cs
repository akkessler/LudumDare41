using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform bulletHolePrefab;

    public AudioClip gunshotSound;

    public float weaponRange = 1000f;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(gunshotSound);

            Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, weaponRange))
            {
                // TODO Use object pooling for bullet holes.
                Transform bulletHole;

                Target t = hit.transform.GetComponent<Target>();
                if (t != null)
                {
                    Vector3 pos = t.transform.position + (-t.transform.forward * .05f);
                    bulletHole = Instantiate(bulletHolePrefab, hit.point + (hit.normal * .005f), Quaternion.FromToRotation(Vector3.up, hit.normal));
                    bulletHole.transform.parent = hit.transform.parent; // parent for scales to work on water wheel?
                    t.SendMessage("TakeDamage");
                    return;
                }
                else
                {
                    // TODO Any other logic for when you miss a shot
                    ScoreKeeper.instance.EndStreak();
                }

                // if we dont hit a target, paint it wherever
                bulletHole = Instantiate(bulletHolePrefab, hit.point + (hit.normal * .005f), Quaternion.FromToRotation(Vector3.up, hit.normal));
                bulletHole.transform.parent = hit.transform;

            }
        }
    }
}
