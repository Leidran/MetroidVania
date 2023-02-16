using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortProjectileBehaviour : MonoBehaviour
{
    float timeAlive = 0f;
    float maxTimeAlive = 0.2f;

    Rigidbody2D rb2D;
    [SerializeField] LayerMask floorLayer;

    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive >= maxTimeAlive)
        {
            Destroy(gameObject);
        }
    }

    public void setProjectileDirectionSpeed(float directionSpeed)
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(directionSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
