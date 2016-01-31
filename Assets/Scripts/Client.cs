using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Client : NetworkBehaviour {

	NetworkClient client;
	public NetworkManager manager;
	public GameObject camera;
	bool hasConnected = false;

	// Use this for initialization
	void Start () {
		client = manager.StartClient ();
		camera.AddComponent<TeamSelectGui> ().client = this.client;
		camera.GetComponent<Camera> ().orthographicSize = 4;
	}
	
	// Update is called once per frame
	void Update () {
		print (client.isConnected);

		print (Input.GetAxis ("Horizontal"));
	}
}
