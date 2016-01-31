using UnityEngine;
using System.Collections;

public class MeteorFlame : MonoBehaviour {

    public bool alive = true;
    public float timeAlive = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(alive && timeAlive >= 20.0f)
        {
            Die();
        }

        timeAlive += Time.smoothDeltaTime;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (alive)
        {
            if (other.gameObject.GetComponent<Extinguish>())
            {
                Die();
            }
            else if (PlayerUnit.localSingleton != null && other.gameObject.GetComponent<PlayerUnit>() == PlayerUnit.localSingleton)
            {
                PlayerUnit.localSingleton.Ignite();
            }
        }
    }

    void Die()
    {
        Destroy(gameObject, 0.25f);
        alive = false;
        foreach (ParticleSystem system in GetComponentsInChildren<ParticleSystem>())
        {
            system.enableEmission = false;
        }
    }
}
