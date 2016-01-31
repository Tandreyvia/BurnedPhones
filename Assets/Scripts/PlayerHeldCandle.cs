using UnityEngine;
using System.Collections;

public class PlayerHeldCandle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(GetComponentInParent<PlayerUnit>().holdingCandle)
        {
			GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
	}
}
