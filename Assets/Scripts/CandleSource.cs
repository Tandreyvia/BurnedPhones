using UnityEngine;
using System.Collections;

public class CandleSource : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(PlayerUnit.localSingleton != null && other.gameObject.GetComponent<PlayerUnit>() == PlayerUnit.localSingleton)
        {
            PlayerUnit.localSingleton.PickUpCandle();
        }
    }
}
