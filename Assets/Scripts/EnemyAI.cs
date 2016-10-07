using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float rotationSpeed;
    public float fireRate;
    public float fireStartDelay;
    public GameObject shotPrefab;
    private Transform shotSpawn;
    private Transform playerTransform;
    private Rigidbody rb;
    private float fireTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        fireTime = Time.time + fireStartDelay;
        shotSpawn = transform.GetChild(0).GetChild(0);
    }

    void FixedUpdate()
    {
        FollowPlayer();
        Shoot();
    }

    void FollowPlayer()
    {
        int playerAngle = (int)playerTransform.rotation.eulerAngles.z;
        int enemyAngle = (int)rb.transform.rotation.eulerAngles.z;
        if (playerAngle == enemyAngle) return;

        int signal = playerAngle - enemyAngle;
        int distanceRight = Mathf.Abs(signal);
        signal = (int)Mathf.Sign(signal);

        if (distanceRight < 180)
        {
            // turn right if signal is +
            rb.transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed * signal);
        }
        else
        {
            // turn left if signal is +
            rb.transform.Rotate(Vector3.forward * Time.deltaTime * -rotationSpeed * signal);
        }
    }

    void Shoot()
    {
        if (Time.time > fireTime)
        {
            Instantiate(shotPrefab, shotSpawn.position, transform.rotation);
            fireTime = Time.time + fireRate + Random.Range(0,1.5f);
        }
    }

}
