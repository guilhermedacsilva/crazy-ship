using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float shootFireRate;
    public GameObject shotPrefab;
    public Transform shotSpawn;

    private float shootTimeOK;
    private Rigidbody rb;
    
	void Start () {
        //rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
	    if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * -speed);
        }
        if (Input.GetKey(KeyCode.Space) && Time.time > shootTimeOK)
        {
            Instantiate(shotPrefab, shotSpawn.position, transform.rotation);
            shootTimeOK = Time.time + shootFireRate;
        }
	}
}
