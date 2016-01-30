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
<<<<<<< HEAD
		camera.AddComponent<TeamSelectGui> ().client = this.client;

=======
>>>>>>> cef55b82cad65a929b824db78452a2fb585de918
	}
	
	// Update is called once per frame
	void Update () {
		print (client.isConnected);

		print (Input.GetAxis ("Horizontal"));
	}
}
