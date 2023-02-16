using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnabler : MonoBehaviour
{
    float currentCharge = 0f;
    float maxCharge = 1f;
    float projectileSpeed = 10f;

    PlayerObjects playerObjects;
    BetterPlayerController playerController;

    void Start()
    {
        playerObjects = GetComponent<PlayerObjects>();
        playerController = GetComponent<BetterPlayerController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            currentCharge += Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.K) && currentCharge >= maxCharge)
        {
            currentCharge = 0f;
            GameObject projectile = Instantiate(playerObjects.projectileLong, transform.position, Quaternion.identity);
            projectile.GetComponent<LongProjectileBehaviour>().setProjectileDirectionSpeed(playerController.GetDirection() * projectileSpeed);
        }
    }
}
