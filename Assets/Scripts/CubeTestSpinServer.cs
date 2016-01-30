using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CubeTestSpinServer : NetworkBehaviour {

	Vector3 axis;

	// Use this for initialization
	void Start () {
		axis = new Vector3 (Random.value, Random.value, Random.value).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		if (isServer) {
			transform.RotateAround (new Vector3 (0, 0, 0), axis, Time.deltaTime * 50);
		}
	}
}
