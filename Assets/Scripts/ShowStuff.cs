using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowStuff : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount > 0)
            GetComponent<Text>().text = Input.GetTouch(0).position.ToString() + Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

    }
}
