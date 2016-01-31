using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SpawnDemonOnCandles : NetworkBehaviour
{

    public GameObject demon;
    public float xSpawnDifference;
    public int candlesNeeded;
    public int goatsNeeded;
    int goatsReceived;
    int candlesReceived;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            if (candlesNeeded <= candlesReceived)
            {
                candlesReceived = 0;
                GameObject newDemon = (GameObject)GameObject.Instantiate(demon, new Vector3(gameObject.transform.position.x + xSpawnDifference, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
                newDemon.GetComponent<DemonScript>().spawnVector = transform.forward;
                NetworkServer.Spawn(newDemon);
            }
        }
    }

    void OnTriggerEnter2d(Collider2D other)
    {
        if(isServer)
        {
            if (candlesReceived < candlesNeeded)
            {
                candlesReceived++;
                other.GetComponent<PlayerUnit>().holdingCandle = false;
            }
            if (goatsReceived < goatsNeeded)
            {
                goatsReceived++;
                if (other.GetComponent<KawaiiGoat>() != null)
                {
                    Destroy(other);
                }
            }
        }
    }
}