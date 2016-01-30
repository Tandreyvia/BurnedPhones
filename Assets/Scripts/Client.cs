using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Client : MonoBehaviour {

	NetworkClient client;
	public NetworkManager manager;
	public GameObject camera;
	bool hasConnected = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (client != null && client.isConnected) {
			hasConnected = true;
			camera.AddComponent<TeamSelectGui> ().client = this.client;
		}
		if (!hasConnected) {
			client = manager.StartClient ();
        }
        print(client.isConnected);

        print(Input.GetAxis("Horizontal"));
	}
}
