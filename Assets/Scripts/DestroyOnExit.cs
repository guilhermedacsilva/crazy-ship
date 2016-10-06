using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour {

	void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shot"))
        {
            Destroy(other.gameObject);
        }
    }
}
