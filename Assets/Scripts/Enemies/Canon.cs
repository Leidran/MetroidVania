using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject Bullet;
    [SerializeField] float timeInterval = 3.0f;
    private float currentTimer;
    [SerializeField] private GameObject target;
    [SerializeField] private float distance;
    [SerializeField] private float range;
    private void Awake()
    {
        shootPoint = GameObject.Find("ShootPoint").transform;
        target = GameObject.Find("Player");
    }

    void Update()
    {
        //measure the distance between the current player position and enemy positon
        distance = Vector2.Distance(transform.position, target.transform.position);
        //Fire the player if it is in range
        if (distance < range)
        {
            Fire();
        }
        
    }
    void Fire()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer > 0) return;

        currentTimer = timeInterval;
        GameObject shootBullet = Instantiate(Bullet,shootPoint.position,shootPoint.rotation);
    }
}
