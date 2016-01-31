using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LevelState : NetworkBehaviour {
    public static LevelState singleton;

    [SyncVar]
    public bool gameActive = false;
    [SyncVar]
    public float blackoutLeft = 0.0f;
    [SyncVar]
    public float blackoutRight = 0.0f;

    // Use this for initialization
    void Start () {
        singleton = this;
	}
	
	// Update is called once per frame
	void Update () {
        blackoutLeft = Mathf.Clamp(blackoutLeft - Time.smoothDeltaTime, 0, 1);
        blackoutRight = Mathf.Clamp(blackoutRight - Time.smoothDeltaTime, 0, 1);
    }
}
