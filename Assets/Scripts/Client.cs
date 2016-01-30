using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Client : MonoBehaviour {

	NetworkClient client;

	// Use this for initialization
	void Start () {
		client = new NetworkClient ();
		client.Connect("127.0.0.1", 1337);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnConnectedToServer () {
		print ("connected");
	}
}
