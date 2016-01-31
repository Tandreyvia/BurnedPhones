using UnityEngine;
using System.Collections;

public class PlayerHeldExtinguisher : MonoBehaviour {

    public Extinguish extinguish;

    float maxExtinguishRange = 4.0f;

    float timeLeftToShoot = 0.0f;
    float timeBetweenShots = 0.125f;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<PlayerUnit>().holdingExtinguisher)
        {
            GetComponent<MeshRenderer>().enabled = true;
            ExtinguishFires();
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void ExtinguishFires()
    {
        if (timeLeftToShoot <= 0.0f)
        {
            MeteorFlame[] flames = Object.FindObjectsOfType<MeteorFlame>();
            MeteorFlame extinguishTarget = null;
            Vector3 extinguishDirection = new Vector3(0, 0, 0);
            foreach (MeteorFlame flame in flames)
            {
                Vector3 distance = flame.transform.position - transform.position;
                distance.z = 0;
                if (distance.magnitude <= maxExtinguishRange)
                {
                    extinguishTarget = flame;
                    extinguishDirection = distance.normalized;
                    break;
                }
            }

            if (extinguishTarget != null)
            {
                timeLeftToShoot = timeBetweenShots;
                ShootExtinguish(extinguishDirection);
            }
        }
        timeLeftToShoot -= Time.smoothDeltaTime;
    }

    void ShootExtinguish(Vector3 direction)
    {
        Extinguish launchedExtinguish = (Extinguish)GameObject.Instantiate(extinguish, transform.position, transform.rotation);
        launchedExtinguish.direction = direction;
    }
}
