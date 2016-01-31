using UnityEngine;
using System.Collections;

public class PlayerGoatingSadness : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponentInParent<PlayerUnit>().timeLeftOnGoating > 0.0f)
        {
            GetComponent<ParticleSystem>().enableEmission = true;
        }
        else
        {
            GetComponent<ParticleSystem>().enableEmission = false;
        }
    }
}
