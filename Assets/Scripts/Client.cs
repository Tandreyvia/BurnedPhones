using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Client : MonoBehaviour {

	NetworkClient client;
	public NetworkManager manager;
	public GameObject cube;
	bool hasConnected = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasConnected) {
			client = manager.StartClient ();
            if (client != null) {
                hasConnected = true;
            }
        }
	}
}
