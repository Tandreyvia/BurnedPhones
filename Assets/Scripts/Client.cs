using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Client : MonoBehaviour {

	NetworkClient client;
	public GameObject cube;

	// Use this for initialization
	void Start () {
		client = new NetworkClient ();
		ClientScene.RegisterPrefab (cube);
		client.Connect("192.168.2.4", 4444);
	
	}
	
	// Update is called once per frame
	void Update () {
		print (client.isConnected);

	}
}
