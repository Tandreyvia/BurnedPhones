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
        if (isServer) {
            timelived += Time.deltaTime;
            if (timelived >= lifetime)
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
            else
            {
                PlayerUnit[] players = Object.FindObjectsOfType<PlayerUnit>();
                PlayerUnit closestPlayer = null;
                float closestDistance = 1000000;
                foreach(PlayerUnit player in players)
                {
                    float distanceFromPlayer = (new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y)).magnitude;
                    if(closestPlayer == null || distanceFromPlayer < closestDistance)
                    {
                        closestPlayer = player;
                        closestDistance = distanceFromPlayer;
                    }
                }
                if(closestPlayer != null)
                {
                    enemy = closestPlayer;
                }
            }
        }
    }
}
