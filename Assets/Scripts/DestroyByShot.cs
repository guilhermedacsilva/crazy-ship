using UnityEngine;
using System.Collections;

public class DestroyByShot : MonoBehaviour {

    public bool playerShot;
    public GameObject otherExplosion;

	void OnTriggerEnter(Collider other)
    {
        if (isValidEnemyShot(other))
        {
            Explode(other.transform);
        }
        else if (isValidPlayerShot(other))
        {
            Explode(other.transform);
        }
    }

    bool isValidEnemyShot(Collider other)
    {
        return !playerShot && other.CompareTag("Player");
    }

    bool isValidPlayerShot(Collider other)
    {
        return playerShot && other.CompareTag("Enemy");
    }

    void Explode(Transform other)
    {
        if (otherExplosion != null)
        {
            Instantiate(
                otherExplosion,
                other.position,
                other.rotation);
        }

        Destroy(other.parent.gameObject);
        Destroy(gameObject);
    }
}
