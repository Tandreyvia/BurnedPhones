using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SpawnOnKey : NetworkBehaviour {

    public GameObject demon;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    if(isServer)
        {
            if(Input.GetKey("d"))
            {
                GameObject newDemon = (GameObject) GameObject.Instantiate(demon, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                newDemon.GetComponent<DemonScript>().spawnVector = transform.forward;
                NetworkServer.Spawn(newDemon);
            }
        }
	}
}
