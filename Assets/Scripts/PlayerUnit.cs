using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerUnit : NetworkBehaviour {
    public static PlayerUnit localSingleton = null;

    Vector2 inputTarget = new Vector2(0, 0);
    bool holdingTap = false;

    float baseMovementSpeed = 6.0f;

    float timeLeftOnFire = 0.0f;
    public bool holdingCandle = false;

    // Use this for initialization
    void Start () {
        if (!isServer && hasAuthority)
        {
            localSingleton = this;
        }
	}

    public void PickUpCandle()
    {
        holdingCandle = true;
    }

    // Update is called once per frame
    void Update () {
        if (!isServer && hasAuthority)
        {
            if (LevelState.singleton.gameActive)
			{
				print ("ha");
                UpdateInput();
                UpdateMovement();
            }
        }
	}

    void UpdateInput()
    {
        holdingTap = (Input.touchCount > 0);

        if(holdingTap)
        {
            Vector3 worldTapLocation = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            inputTarget = new Vector2(worldTapLocation.x, worldTapLocation.y);
        }
    }

    void UpdateMovement()
    {
        // on mobile touchscreen
        if (AbleToMove() && holdingTap)
        {
            Vector3 velocity = new Vector3(inputTarget.x, inputTarget.y, transform.position.z)
                             - new Vector3(transform.position.x, transform.position.y, transform.position.z);

            velocity = velocity.normalized * CalculateNetMovementSpeed();

            transform.Translate(velocity * Time.smoothDeltaTime);
        }

        // for debugging on pc
        Vector3 debugVelocity = new Vector3(0, 0, 0);
        if (Input.GetKeyDown("w"))  debugVelocity += new Vector3(0, -1, 0);
        if (Input.GetKeyDown("s"))  debugVelocity += new Vector3(0, 1, 0);
        if (Input.GetKeyDown("a"))  debugVelocity += new Vector3(-1, 0, 0);
        if (Input.GetKeyDown("d"))  debugVelocity += new Vector3(1, 0, 0);
        transform.Translate(debugVelocity.normalized * baseMovementSpeed * Time.smoothDeltaTime);
    }

    public float CalculateNetMovementSpeed()
    {
        return baseMovementSpeed;
    }

    public bool AbleToMove()
    {
        return timeLeftOnFire <= 0;
    }
}
