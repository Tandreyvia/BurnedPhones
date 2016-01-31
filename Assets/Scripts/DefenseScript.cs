using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class DefenseScript : NetworkBehaviour {
    public float lifetime;
    float timeSinceStart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceStart += Time.deltaTime;
        if(lifetime <= timeSinceStart)
        {
            Destroy(gameObject);
            return;
        }
	}

    void onTriggerEnter2d(Collider2D other)
    {
        if(isServer)
        {
            if(other.GetComponent<DemonScript>() != null)
            {
                Destroy(other);
            }
        }
    }
}
