using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class KawaiiGhost : NetworkBehaviour
{

    public PlayerUnit enemy = null;

    public float movementSpeed = 3.0f;
    public float lifetime;
    float timelived;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timelived += Time.deltaTime;
        if(timelived >= lifetime)
        {
            Destroy(gameObject);
            return;
        }
        if (enemy != null)
        {
            Vector3 velocity = enemy.transform.position - transform.position;
            velocity.z = 0;

            transform.Translate(velocity.normalized * movementSpeed * Time.smoothDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (enemy != null)
        {
            if (other.gameObject.GetComponent<PlayerUnit>() == enemy)
            {
                //Do the antimovement thing here
            }
        }
    }
}
