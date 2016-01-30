using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CubeTestSpinServer : NetworkBehaviour {

	Vector3 axis;
	public Transform start;
	public Transform second;
	bool which = true;

    float timeUntilNextMove = 0.0f;
    float timeBetweenMoves = 1.0f;

	// Use this for initialization
	void Start () {
		axis = new Vector3 (Random.value, Random.value, Random.value).normalized;
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
