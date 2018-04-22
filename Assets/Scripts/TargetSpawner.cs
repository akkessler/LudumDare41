using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public const float PI = 3.14159f; // approximate pi for efficiency
    public const float TWO_PI = 2 * PI;

    public WaterWheel waterWheel;
    public Transform targetPrefab;
    public int numTargetSections = 16;

    List<Target> targets;

    void Start()
    {
        targets = new List<Target>();
        float inc = TWO_PI / numTargetSections;
        for (float theta = 0f; targets.Count < numTargetSections; theta += inc)
        {
            float degrees = theta * 180f / PI;
            Transform target = Instantiate(targetPrefab, waterWheel.transform);

            float x = Mathf.Cos(theta);
            float y = Mathf.Sin(theta);
            float z = Random.Range(-0.75f, 0.75f);

            target.name = "Target" + degrees;
            target.localPosition = new Vector3(x, y, z);
            target.Rotate(Vector3.forward, degrees);
            targets.Add(target.GetComponent<Target>());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BulletHole")
        {
            Destroy(other.transform.gameObject); // TODO Use object pooling for bullet holes.
            return;
        }

        Target t = other.GetComponent<Target>();
        if (t != null)
        {
            t.transform.localPosition = new Vector3(t.transform.localPosition.x, t.transform.localPosition.y, Random.Range(-0.75f, 0.75f));
            t.ResetState();
        }
    }
}
