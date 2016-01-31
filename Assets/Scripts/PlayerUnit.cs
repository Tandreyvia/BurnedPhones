using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

public class PlayerUnit : NetworkBehaviour {
    public static PlayerUnit localSingleton = null;

    Vector2 inputTarget = new Vector2(0, 0);
    bool holdingTap = false;

    float baseMovementSpeed = 6.0f;
    float burningMovementSpeed = 10.0f;

    public float timeLeftOnFire = 0.0f;
    float timeLeftFireImmunity = 0.0f;

    public bool holdingCandle = false;
    public bool holdingExtinguisher = false;

    float timeLeftUntilBurningDirectionChange = 0.0f;
    Vector3 burningVelocity = new Vector3(0, 0, 0);

    public float timeLeftOnGoating = 0.0f;
    float totalGoatingDuration = 0.5f;

    int movementMethod = 1;
    Vector2 joystickDirection = new Vector2(0, 0);

    // Use this for initialization
    void Start () {
        if (!isServer && hasAuthority)
        {
            localSingleton = this;
        }
	}

    public void PickUpCandle()
    {
        DropExtinguisher();
        holdingCandle = true;
    }

    public void DropCandle()
    {
        holdingCandle = false;
    }

    public void PickUpExtinguisher()
    {
        DropCandle();
        holdingExtinguisher = true;
    }

    public void DropExtinguisher()
    {
        holdingExtinguisher = false;
    }

    public void Ignite()
    {
        if(timeLeftOnFire <= 0.0f && timeLeftFireImmunity <= 0.0f && !holdingExtinguisher)
        {
            timeLeftOnFire = 5.0f;
            timeLeftFireImmunity = 7.0f;
        }
    }

    public void GetGoated()
    {
        timeLeftOnGoating = totalGoatingDuration;
    }

    // Update is called once per frame
    void Update () {
        if (!isServer && hasAuthority)
        {
            if (LevelState.singleton.gameActive)
			{
                UpdateInput();
                UpdateMovement();

                timeLeftOnFire -= Time.smoothDeltaTime;
                timeLeftFireImmunity -= Time.smoothDeltaTime;
                timeLeftUntilBurningDirectionChange -= Time.smoothDeltaTime;
                timeLeftOnGoating -= Time.smoothDeltaTime;
            }
        }
	}

    void UpdateInput()
    {
        // old movement mode (dont remove)
        if (movementMethod == 1)
        {
            holdingTap = (Input.touchCount > 0);

            if (holdingTap)
            {
                Vector3 worldTapLocation = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                inputTarget = new Vector2(worldTapLocation.x, worldTapLocation.y);
            }
        }
        else if (movementMethod == 2)
        {
            // new movement mode with joystick
            joystickDirection = new Vector2(0, 0);

            // x
            if (CrossPlatformInputManager.GetAxis("Horizontal") >= 0.5f)
            {
                joystickDirection.x = 1.0f;
            }
            else if (CrossPlatformInputManager.GetAxis("Horizontal") <= -0.5f)
            {
                joystickDirection.x = -1.0f;
            }
            else
            {
                joystickDirection.x = 0.0f;
            }

            // y
            if (CrossPlatformInputManager.GetAxis("Vertical") >= 0.5f)
            {
                joystickDirection.y = 1.0f;
            }
            else if (CrossPlatformInputManager.GetAxis("Vertical") <= -0.5f)
            {
                joystickDirection.y = -1.0f;
            }
            else
            {
                joystickDirection.y = 0.0f;
            }
        }
        else if (movementMethod == 3)
        {
            // allows free movement in more than 8 directions, and variable speed
            joystickDirection.x = CrossPlatformInputManager.GetAxis("Horizontal");
            joystickDirection.y = CrossPlatformInputManager.GetAxis("Vertical");
        }
    }

    void UpdateMovement()
    {
        if (AbleToMove())
        {
            if (movementMethod == 1)
            {
                if (holdingTap)
                {
                    Vector3 velocity = new Vector3(inputTarget.x, inputTarget.y, transform.position.z)
                                     - new Vector3(transform.position.x, transform.position.y, transform.position.z);

                    velocity = velocity.normalized * CalculateNetMovementSpeed();

                    transform.Translate(velocity * Time.smoothDeltaTime);
                }
            }
            else if (movementMethod == 2)
            {
                if (joystickDirection.x != 0 || joystickDirection.y != 0)
                {
                    transform.Translate(joystickDirection.normalized * CalculateNetMovementSpeed() * Time.smoothDeltaTime);
                }
            }
            else if (movementMethod == 3)
            {
                if (joystickDirection.x != 0 || joystickDirection.y != 0)
                {
                    transform.Translate(joystickDirection * CalculateNetMovementSpeed() * Time.smoothDeltaTime);
                }
            }
        }
        else if (timeLeftOnFire > 0.0f)
        {
            if (timeLeftUntilBurningDirectionChange <= 0.0f)
            {
                float directionSeed = Random.value * Mathf.PI * 2.0f;
                burningVelocity = new Vector3(Mathf.Cos(directionSeed), Mathf.Sin(directionSeed), 0).normalized;

                timeLeftUntilBurningDirectionChange = 0.125f;
            }

            transform.Translate(burningVelocity * burningMovementSpeed * Time.smoothDeltaTime);
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
        return timeLeftOnFire <= 0 && timeLeftOnGoating <= 0;
    }

	public void SetPosition(Vector2 t) {
		RpcSetPosition (t);
	}

    public void GiveCandle()
    {
        CmdGiveCandleToServer();
    }

    [Command]
    void CmdGiveCandleToServer()
    {
        print("candle received");
        SpawnDemonOnCandles spawnToUse = null;
        SpawnDemonOnCandles[] spawns = Object.FindObjectsOfType<SpawnDemonOnCandles>();
        SpawnDemonOnCandles closestSpawn = null;
        float closestDistance = 1000000;
        foreach (SpawnDemonOnCandles currentSpawn in spawns)
        {
            float distanceFromPlayer = (new Vector2(currentSpawn.transform.position.x - transform.position.x, currentSpawn.transform.position.y - transform.position.y)).magnitude;
            if (closestSpawn == null || distanceFromPlayer < closestDistance)
            {
                closestSpawn = currentSpawn;
                closestDistance = distanceFromPlayer;
            }
        }
        if (closestSpawn != null)
        {
            print("found spawn");
            spawnToUse = closestSpawn;
        }

        if(spawnToUse != null)
        {
            spawnToUse.candlesReceived++;
        }
    }

    [ClientRpc]
	void RpcSetPosition(Vector3 t) {
		gameObject.transform.position = t;
	}
}
