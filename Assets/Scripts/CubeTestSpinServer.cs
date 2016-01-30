using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CubeTestSpinServer : NetworkBehaviour {

	Vector3 axis;
	public Transform start;
	public Transform second;
	bool which = true;


	// Use this for initialization
	void Start () {
		axis = new Vector3 (Random.value, Random.value, Random.value).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		if (isServer) {
		}
	}
}
