using UnityEngine;
using System.Collections;

public class GlobalBlackout : MonoBehaviour {

    public bool isLeftBlackout = true;

    float baseX;
    float xOffset = 0.0f;
    float maxXOffset = 15.0f;

    // Use this for initialization
    void Start () {
        baseX = transform.position.x;
        xOffset = maxXOffset;
    }
	
	// Update is called once per frame
	void Update () {
        if (IsCurrentlyBlackedOut())
            xOffset = Mathf.Clamp(xOffset - maxXOffset / 2.0f * Time.smoothDeltaTime, 0, maxXOffset);
        else
            xOffset = Mathf.Clamp(xOffset + maxXOffset / 2.0f * Time.smoothDeltaTime, 0, maxXOffset);

        float finalXOffset = xOffset;
        if (isLeftBlackout)
            finalXOffset *= -1;
        transform.position = new Vector3(baseX + finalXOffset, transform.position.y, transform.position.z);


        foreach(ParticleSystem system in GetComponentsInChildren<ParticleSystem>())
        {
            system.enableEmission = IsCurrentlyBlackedOut();
        }
    }

    bool IsCurrentlyBlackedOut()
    {
        if (PlayerUnit.localSingleton != null)
            return false;

        return (isLeftBlackout && LevelState.singleton.blackoutLeft)
            || (!isLeftBlackout && LevelState.singleton.blackoutRight);
    }
}
