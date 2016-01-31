using UnityEngine;
using System.Collections;

public class Extinguish : MonoBehaviour {

    public Vector3 direction;
    public float currentSpeed = 5.0f;
    public float lifetime = 0.5f;

    public float timeAlive = 0.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction.normalized * currentSpeed * Time.smoothDeltaTime);

        if(timeAlive >= lifetime)
        {
            Destroy(gameObject, 0.125f);
            foreach(ParticleSystem system in GetComponents<ParticleSystem>())
            {
                system.enableEmission = false;
            }
        }

        timeAlive += Time.smoothDeltaTime;
	}
}
