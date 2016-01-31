using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour {

    public float duration = 3.05f;
    public float timeBetweenSpawns = 0.5f;
    public float timeActive = 0.0f;
    public float timeUntilNextSpawn;

    public GameObject meteor;

    float maxWaves;
    float wavesLaunched = 0;

    // Use this for initialization
    void Start () {
        timeUntilNextSpawn = timeBetweenSpawns;
        maxWaves = (int)(duration / timeBetweenSpawns);
	}
	
	// Update is called once per frame
	void Update () {
        timeUntilNextSpawn -= Time.smoothDeltaTime;
        timeActive += Time.smoothDeltaTime;

        if (timeUntilNextSpawn <= 0.0f && wavesLaunched < maxWaves) {
            Bounds targetBounds = GetComponent<BoxCollider2D>().bounds;
            Vector3 meteorTarget = new Vector3((targetBounds.center.x - targetBounds.extents.x) + (Random.value * targetBounds.extents.x * 2),
                                               (targetBounds.center.y - targetBounds.extents.y) + (Random.value * targetBounds.extents.y * 2),
                                                0);
            GameObject.Instantiate(meteor, meteorTarget, transform.rotation);

            wavesLaunched++;
            timeBetweenSpawns += timeBetweenSpawns;
        }

        if(timeActive >= duration)
        {
            Destroy(gameObject);
        }
    }
}
