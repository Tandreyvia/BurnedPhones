using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Server : NetworkBehaviour {

	public GameObject cube;
	public NetworkManager manager;
	bool first = false;

	// Use this for initialization
	void Start () {
		NetworkServer.RegisterHandler (MsgType.Connect, OnClientConnected);

		manager.StartServer ();
		NetworkServer.RegisterHandler (MsgType.Connect, OnClientConnected);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnClientConnected(NetworkMessage netMsg)
    {
		NetworkServer.Spawn((GameObject)GameObject.Instantiate (cube,Vector3.zero, transform.rotation));
    }
}
