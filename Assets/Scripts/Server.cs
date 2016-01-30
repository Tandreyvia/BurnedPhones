using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Server : NetworkBehaviour {

	public GameObject cube;
	public NetworkManager manager;
	bool first = false;

	// Use this for initialization
	void Start () {
		manager.StartServer ();
	}
	
	// Update is called once per frame
	void Update () {
		if (NetworkServer.connections.Count > 0 && !first) {
			NetworkServer.Spawn((GameObject)GameObject.Instantiate (cube,Vector3.zero, transform.rotation));
			first = true;
		}
	}

    void OnClientConnected()
    {
        print("rawr");
    }
	
}
