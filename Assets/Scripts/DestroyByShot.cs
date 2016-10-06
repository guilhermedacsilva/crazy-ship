using UnityEngine;
using System.Collections;

public class DestroyByShot : MonoBehaviour {

    public GameObject otherExplosion;

	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (otherExplosion != null)
            {
                Instantiate(
                    otherExplosion, 
                    other.transform.position, 
                    other.transform.rotation);
            }

            Destroy(other.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}
