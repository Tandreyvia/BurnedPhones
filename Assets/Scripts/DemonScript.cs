using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DemonScript : NetworkBehaviour {

    public float velocity;
    public float spawnTime;
    float timeSinceSpawn;
    public Vector3 spawnVector;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (timeSinceSpawn < spawnTime) {
            timeSinceSpawn += Time.deltaTime;
        }
	    else
        {
            transform.Translate(spawnVector * Time.deltaTime * velocity);
        }
	}
}
