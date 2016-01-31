using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BaseHealth : NetworkBehaviour {

    [SyncVar]
    public int maxHealth;
    int health;
    public int rgbDamage;
    public int goldDamage;

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (isServer)
        {
            if (health <= 0)
            {
                LevelState.singleton.gameActive = false;
                if(gameObject.transform.position.x < 0)
                {
                    //Blue team wins
                }
                else
                {
                    //Red team wins
                }
                //Handle the x team won stuff here
            }
        }
	}

    void OnTriggerEnter2d(Collider2D other)
    {
		print ("trigger");
        if (isServer)
        {
			print ("isserver");
            if (other.GetComponent<DemonScript>() != null)
            {
				print ("a deomo");
                if(other.GetComponent<DemonScript>().whichDemon == DemonScript.demonColor.Gold)
                {
					print ("one demon");
                    health -= goldDamage;
                }
                else
                {
					print ("one demon");

                    health -= rgbDamage;
                }
				Destroy(other.gameObject);
            }
        }
    }
}
