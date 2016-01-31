using UnityEngine;
using System.Collections;

public class CandleCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.localPosition = new Vector3(0.00965001f, 0.161262f, -0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        int candlesNeededLeft = GetComponentInParent<SpawnDemonOnCandles>().candlesNeeded - GetComponentInParent<SpawnDemonOnCandles>().candlesReceived;
        GetComponent<TextMesh>().text = candlesNeededLeft.ToString();
	}
}
