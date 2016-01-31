using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GoatSpawning : NetworkBehaviour {
    public float timeBetweenSpawns = 8.0f;
    public float timeUntilNextSpawn;

    public GameObject kawaii;

    // Use this for initialization
    void Start () {
		timeUntilNextSpawn = timeBetweenSpawns;
	}
	
	// Update is called once per frame
	void Update () {
		if(isServer) {
			timeUntilNextSpawn -= Time.smoothDeltaTime;
			if (timeUntilNextSpawn <= 0.0f) {
				Bounds targetBounds = GetComponent<BoxCollider2D> ().bounds;
				Vector3 goatTarget = new Vector3 ((targetBounds.center.x - targetBounds.extents.x) + (Random.value * targetBounds.extents.x * 2),
					                              (targetBounds.center.y - targetBounds.extents.y) + (Random.value * targetBounds.extents.y * 2),
					                              0);
				NetworkServer.Spawn((GameObject)GameObject.Instantiate (kawaii, goatTarget, transform.rotation));

				timeUntilNextSpawn += timeBetweenSpawns;
			}
        }
    }
}
