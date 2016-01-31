using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class Blackout : MonoBehaviour {

    public bool blackoutOn = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(LevelState.singleton.blackoutLeft > 0 && PlayerUnit.localSingleton != null && PlayerUnit.localSingleton.transform.position.x < 0)
        {
            blackoutOn = true;
        }
        else if (LevelState.singleton.blackoutRight > 0 && PlayerUnit.localSingleton != null && PlayerUnit.localSingleton.transform.position.x > 0)
        {
            blackoutOn = true;
        }
        else
        {
            blackoutOn = false;
        }

        Image image = GetComponent<Image>();
        if (blackoutOn)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp(image.color.a + 0.25f * Time.smoothDeltaTime, 0, 1));
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Clamp(image.color.a - 1.0f * Time.smoothDeltaTime, 0, 1));
        }
    }
}
