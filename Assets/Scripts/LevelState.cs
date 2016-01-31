using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LevelState : NetworkBehaviour {
    public static LevelState singleton;

    [SyncVar]
    public bool gameActive = false;
    [SyncVar]
    public bool blackoutLeft = false;
    [SyncVar]
    public bool blackoutRight = false;

    // Use this for initialization
    void Start () {
        singleton = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
