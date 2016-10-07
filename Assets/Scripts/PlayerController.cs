using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float rotationSpeed;
    public float shootFireRate;
    public GameObject shotPrefab;
    public Transform shotSpawn;

    private float shootTimeOK;
    private Rigidbody rb;
    
	void Start () {
        //rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
	    if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            MobileControls();
        } else
        {
            PcControls();
        }
	}

    void PcControls()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * -rotationSpeed);
        }
        if (Time.time > shootTimeOK && Input.GetKey(KeyCode.Space))
        {
            Instantiate(shotPrefab, shotSpawn.position, transform.rotation);
            shootTimeOK = Time.time + shootFireRate;
        }
    }

    void MobileControls()
    {
        /*
         * speed
         * 0.4 = 1
         * 0.3 = 0.75
         * 0.2 = 0.5
         * 0.1 = 0.25
         */
        float x = Input.acceleration.x;
        if (x > 0.05 || x < -0.05)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed * x * 2.5f);
        }
        if (Time.time > shootTimeOK 
            && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Instantiate(shotPrefab, shotSpawn.position, transform.rotation);
            shootTimeOK = Time.time + shootFireRate;
        }
    }
}
