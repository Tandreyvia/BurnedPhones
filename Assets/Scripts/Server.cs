using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Server : MonoBehaviour {

	public GameObject cube;

	// Use this for initialization
	void Start () {
		NetworkServer.Listen (4444);
		NetworkServer.Spawn (cube);
	}
	
	// Update is called once per frame
	void Update () {

		print (NetworkServer.connections.Count);
	
	}
	
}
