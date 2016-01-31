using UnityEngine;
using System.Collections;

public class KawaiiGoatRabu : MonoBehaviour {

    bool visible = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(GetComponentInParent<KawaiiGoat>() != null)
        {
            visible = GetComponentInParent<KawaiiGoat>().friend != null;
        }

        if (GetComponentInParent<KawaiiGhost>() != null)
        {
            visible = GetComponentInParent<KawaiiGhost>().enemy != null;
        }

        GetComponent<SpriteRenderer>().enabled = visible;
    }
}
