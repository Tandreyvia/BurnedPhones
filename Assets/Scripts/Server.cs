using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Server : NetworkBehaviour {

	public GameObject cube;
	NetworkClient local;

	// Use this for initialization
	void Start () {
		NetworkServer.Listen (4444);
	}
	
	// Update is called once per frame
	void Update () {
		if (NetworkServer.connections.Count > 0) {
			NetworkServer.Spawn (cube);
		}
	
	}
	
}
