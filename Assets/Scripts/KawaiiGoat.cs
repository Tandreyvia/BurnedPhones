﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class KawaiiGoat : NetworkBehaviour {

    public PlayerUnit friend = null;

    public float movementSpeed = 3.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(friend != null)
        {
            Vector3 velocity = friend.transform.position - transform.position;
            velocity.z = 0;

            Vector3 distance = velocity;

            if(distance.magnitude > 1.0f)
                transform.Translate(velocity.normalized * movementSpeed * Time.smoothDeltaTime);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (friend == null)
        {
            if (other.gameObject.GetComponent<PlayerUnit>() != null)
            {
                friend = other.gameObject.GetComponent<PlayerUnit>();
            }
        }
    }
}
