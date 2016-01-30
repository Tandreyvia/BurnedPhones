using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Server : MonoBehaviour {


	// Use this for initialization
	void Start () {
		NetworkServer.Listen (4444);
	}
	
	// Update is called once per frame
	void Update () {

		print (NetworkServer.connections.Count);
	
	}
	
}
