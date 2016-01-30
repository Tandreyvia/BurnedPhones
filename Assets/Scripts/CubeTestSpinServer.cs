using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CubeTestSpinServer : NetworkBehaviour {

    float timeUntilNextMove = 0.0f;
    float timeBetweenMoves = 1.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (isServer) {
            
            if(timeUntilNextMove <= 0)
            {
                transform.position = new Vector3(-2 + Random.value * 4, -2 + Random.value * 4, transform.position.z);
                timeUntilNextMove = timeBetweenMoves;
            }
            timeUntilNextMove -= Time.smoothDeltaTime;
        }
	}
}
