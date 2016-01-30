using UnityEngine;
using System.Collections;

public class BPCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerUnit.localSingleton != null)
        {
            transform.position = new Vector3(PlayerUnit.localSingleton.transform.position.x,
                                             PlayerUnit.localSingleton.transform.position.y,
                                             transform.position.z);
        }
	}
}
