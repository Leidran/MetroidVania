using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject projectile = Instantiate(playerObjects.projectileShort, transform.position, Quaternion.identity);
            projectile.GetComponent<ShortProjectileBehaviour>().setProjectileDirectionSpeed(playerController.GetDirection() * projectileSpeed);
        }
    }
}