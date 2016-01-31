using UnityEngine;
using System.Collections;

public class GoatCounter : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        transform.localPosition = new Vector3(0.00965001f, 0.221262f, -0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        int goatsNeededLeft = GetComponentInParent<SpawnDemonOnCandles>().goatsNeeded - GetComponentInParent<SpawnDemonOnCandles>().goatsReceived;
        GetComponent<TextMesh>().text = goatsNeededLeft.ToString();
    }
}
