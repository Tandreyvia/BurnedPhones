using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SpawnDemonOnCandles : NetworkBehaviour
{

    public GameObject demon;
    public float xSpawnDifference;
    public int candlesNeeded;
    public int goatsNeeded;
	[SyncVar]
    public int goatsReceived;
	[SyncVar]
    public int candlesReceived;

    public bool causeDarkness = false;
    public bool causeMeteor = false;
    public bool causeGhoasts = false;

    public GameObject meteors;
    public GameObject ghoast;

    public float meteorXOffset = 9.0f;
    public float ghoastXOffset = 11.0f;
    public float ghoastYExtent = 5.0f;

    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
			if (candlesNeeded <= candlesReceived && goatsNeeded <= goatsReceived)
            {
                if (demon != null)
                {
                    print("demon");
                    candlesReceived = 0;
                    goatsReceived = 0;
                    GameObject newDemon = (GameObject)GameObject.Instantiate(demon, new Vector3(gameObject.transform.position.x + xSpawnDifference, gameObject.transform.position.y), transform.rotation);
                    newDemon.GetComponent<DemonScript>().spawnVector = transform.forward;
                    NetworkServer.Spawn(newDemon);
                }
                if(causeDarkness)
                {
                    if(transform.position.x > 0)
                        LevelState.singleton.blackoutLeft = 10.0f;
                    else
                        LevelState.singleton.blackoutRight = 10.0f;
                }
                if (causeMeteor)
                {
                    if (transform.position.x > 0)
                    {
                        GameObject newMeteors = (GameObject)GameObject.Instantiate(meteors, new Vector3(-meteorXOffset, 0.0f, 0.0f), transform.rotation);
                        NetworkServer.Spawn(newMeteors);
                    }
                    else
                    {
                        GameObject newMeteors = (GameObject)GameObject.Instantiate(meteors, new Vector3(meteorXOffset, 0.0f, 0.0f), transform.rotation);
                        NetworkServer.Spawn(newMeteors);
                    }
                }
                if (causeGhoasts)
                {
                    if (transform.position.x > 0)
                    {
                        for (int count = 1; count <= 4; count++)
                        {
                            GameObject newGhoast = (GameObject)GameObject.Instantiate(ghoast, new Vector3(-ghoastXOffset, -ghoastYExtent + count / 4.0f * ghoastYExtent * 2.0f, 0.0f), transform.rotation);
                            NetworkServer.Spawn(newGhoast);
                        }
                    }
                    else
                    {
                        for (int count = 1; count <= 4; count++)
                        {
                            GameObject newGhoast = (GameObject)GameObject.Instantiate(ghoast, new Vector3(ghoastXOffset, -ghoastYExtent + count / 4.0f * ghoastYExtent * 2.0f, 0.0f), transform.rotation);
                            NetworkServer.Spawn(newGhoast);
                        }
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isServer)
        {
            print("ontriggerenter");
            if (candlesReceived < candlesNeeded && PlayerUnit.localSingleton != null && other.gameObject.GetComponent<PlayerUnit>() == PlayerUnit.localSingleton)
            {
                if (PlayerUnit.localSingleton.holdingCandle && candlesReceived < candlesNeeded)
                {
                    PlayerUnit.localSingleton.holdingCandle = false;
                    PlayerUnit.localSingleton.GiveCandle();
                }
            }
        }
        else
        {
            if (goatsReceived < goatsNeeded && other.GetComponent<KawaiiGoat>() != null)
            {
                print("goat received");
                goatsReceived++;
                Destroy(other.gameObject);
            }
        }

			
     /*   if(isServer)
        {
            if (candlesReceived < candlesNeeded)
            {
                candlesReceived++;
                other.GetComponent<PlayerUnit>().holdingCandle = false;
            }
            if (goatsReceived < goatsNeeded)
            {
                if (other.GetComponent<KawaiiGoat>() != null)
                {
                    goatsReceived++;
                    Destroy(other);
                }
            }
        }*/
    }
}