using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugText : MonoBehaviour {

    public Text textObj;

	void Update () {
        Vector3 dir = Vector3.zero;
        dir.x = -Input.acceleration.x;
        dir.y = Input.acceleration.y;
        dir.z = Input.acceleration.z;
        textObj.text = dir.ToString();
    }
}
