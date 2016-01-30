using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Client : MonoBehaviour {

	NetworkClient client;
	public NetworkManager manager;
	public GameObject cube;

	// Use this for initialization
	void Start () {
		client = manager.StartClient ();
	}
	
	// Update is called once per frame
	void Update () {
		print (client.isConnected);

	}
}
