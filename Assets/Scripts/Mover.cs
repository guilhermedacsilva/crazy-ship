using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public Vector3 speed;
    public MinMax limitZ;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        Vector3 startPosition = rb.transform.position;
        
        if (speed.z != 0 && startPosition.z > limitZ.min && startPosition.z < limitZ.max)
        {
            Vector3 finalPosition = startPosition + new Vector3(0,0,Time.deltaTime * speed.z);
            rb.transform.position = new Vector3(
                finalPosition.x,
                finalPosition.y,
                Mathf.Clamp(finalPosition.z, limitZ.min, limitZ.max)
            );
        }
    }



}
