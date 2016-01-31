using UnityEngine;
using System.Collections;

public class MeteorSprite : MonoBehaviour {

    float fallSpeed = 10.0f;
    float distanceToTravel = new Vector2(8, 8).magnitude;
    bool alive = true;
    bool placedFires = false;
    float timeImpacted = 0;

    public GameObject boom;
    public GameObject flame;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = (new Vector3(-1, -1, 0).normalized * fallSpeed * Time.smoothDeltaTime);

        distanceToTravel -= movement.magnitude;
        if (distanceToTravel <= 0 && alive)
        {
            alive = false;
            foreach (ParticleSystem system in GetComponentsInChildren<ParticleSystem>())
            {
                system.enableEmission = false;
            }
            GameObject.Instantiate(boom, transform.position, transform.rotation);
        }
        else if(alive)
        {
            transform.Translate(movement);
        }

        if (!alive)
            timeImpacted += Time.smoothDeltaTime;

        if (timeImpacted >= 0.2f && !placedFires)
        {
            placedFires = true;
            GameObject.Instantiate(flame, transform.position, transform.rotation);
            for (int count = 0; count < 2; count++)
            {
                float seed = Random.value * Mathf.PI * 2;
                Vector3 randomOffset = new Vector3(Mathf.Cos(seed) * 1.5f, Mathf.Sin(seed) * 1.5f, 0);
                GameObject.Instantiate(flame, transform.position + randomOffset, transform.rotation);
            }
            for (int count = 0; count < 2; count++)
            {
                float seed = Random.value * Mathf.PI * 2;
                Vector3 randomOffset = new Vector3(Mathf.Cos(seed) * 0.75f, Mathf.Sin(seed) * 0.75f, 0);
                GameObject.Instantiate(flame, transform.position + randomOffset, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
