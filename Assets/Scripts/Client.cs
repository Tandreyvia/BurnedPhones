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
	}
	
	// Update is called once per frame
	void Update () {
        print(client.isConnected);

        print(Input.GetAxis("Horizontal"));
	}

	public override void OnStartClient()
	{
		camera.AddComponent<TeamSelectGui> ().client = this.client;
	}
}
