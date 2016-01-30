using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using System.Collections;

public class TeamSelectGui : MonoBehaviour {
	public NetworkClient client;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect (10, 140, 100, 100), "red team")) {
			client.Send (MsgType.Highest + 1, new EmptyMessage());
			DestroyImmediate (this);
		}
		if (GUI.Button (new Rect (150, 140, 100, 100), "blue team")) {
			client.Send (MsgType.Highest + 2, new EmptyMessage());
			DestroyImmediate (this);
		}
	}
}
