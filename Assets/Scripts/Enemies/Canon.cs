using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject Bullet;
    [SerializeField] float timeInterval = 3.0f;
    private float currentTimer;
    private void Awake()
    {
        shootPoint = GameObject.Find("ShootPoint").transform;
    }

    void Update()
    {
        Fire();
    }
    void Fire()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer > 0) return;

        currentTimer = timeInterval;
        GameObject shootBullet = Instantiate(Bullet,shootPoint.position,shootPoint.rotation);
    }
}
