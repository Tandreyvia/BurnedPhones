using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class Server : NetworkBehaviour {

	public enum Team {
		Red, Blue, Undeclared
	}

	public NetworkManager manager;
	List<NetworkConnection> connections = new List<NetworkConnection>();
	public List<Team> teams = new List<Team> ();

    public GameObject goat;


	// Use this for initialization
	void Start () {
        //manager.connectionConfig.FragmentSize = 1000;
        //manager.connectionConfig.MaxSentMessageQueueSize = 5000;
		manager.StartServer ();
		NetworkServer.RegisterHandler (MsgType.Connect, OnClientConnected);
		NetworkServer.RegisterHandler (MsgType.Highest + 1, OnRedDecide);
		NetworkServer.RegisterHandler (MsgType.Highest + 2, OnRedDecide);

	}
	
	// Update is called once per frame
	void Update () {
	}

	NetworkConnection checkingEquality;

	bool dumbEquals (NetworkConnection dumb){
		if (checkingEquality == null) {
			return false;
		} else {
			return dumb.Equals (checkingEquality);
		}
	}

	void OnClientConnected(NetworkMessage netMsg)
    {
		connections.Add (netMsg.conn);
		teams.Add (Team.Undeclared);
        NetworkServer.Spawn((GameObject)GameObject.Instantiate (goat, new Vector3(2, 4, transform.position.z), transform.rotation));
        print("meow~");
    }

	void OnRedDecide(NetworkMessage netMsg) {
		checkingEquality = netMsg.conn;
		int connIndex = connections.FindIndex (dumbEquals);
		if (connIndex == -1)
			return;
		teams [connIndex] = Team.Red;
		print ("red");
	}

	void OnBlueDecide(NetworkMessage netMsg) {
		checkingEquality = netMsg.conn;
		int connIndex = connections.FindIndex (dumbEquals);
		if (connIndex == -1)
			return;
		teams [connIndex] = Team.Blue;
		print ("blue");
	}
}
