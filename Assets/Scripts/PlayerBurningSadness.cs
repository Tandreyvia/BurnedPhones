using UnityEngine;
using System.Collections;

public class PlayerBurningSadness : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponentInParent<PlayerUnit>().timeLeftOnFire > 0.0f)
        {
            GetComponent<ParticleSystem>().enableEmission = true;
        }
        else
        {
            GetComponent<ParticleSystem>().enableEmission = false;
        }
    }
}
