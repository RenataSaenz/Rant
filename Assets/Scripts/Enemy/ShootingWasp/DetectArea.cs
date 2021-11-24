using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectArea : MonoBehaviour
{
    bool detected;
    GameObject target;
    public Transform enemy;
    public GameObject bullet;
    public Transform shootPoint;

    public float speed = 10f;
    public float timeToShoot = 1.3f;
    float originalTime;

    private void Start()
    {
        originalTime = timeToShoot;
    }

    void Update()
    {
        if (detected)
        {
            enemy.LookAt(target.transform);
            timeToShoot -= Time.deltaTime;
            if (timeToShoot < 0)
            {
                Shoot();
                timeToShoot = originalTime;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            detected = true;
            target = other.gameObject;
        }
    }

    private void Shoot()
    {
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);

        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }
}
