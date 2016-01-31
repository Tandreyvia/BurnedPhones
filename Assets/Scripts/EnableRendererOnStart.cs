using UnityEngine;
using System.Collections;

public class EnableRendererOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
