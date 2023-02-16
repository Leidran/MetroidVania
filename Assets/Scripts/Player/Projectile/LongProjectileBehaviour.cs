using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongProjectileBehaviour : MonoBehaviour
{
    float timeAlive = 0f;
    float maxTimeAlive = 4f;

    Rigidbody2D rb2D;
    [SerializeField] LayerMask floorLayer;

    void Start()
    {
        //rb2D = GetComponent<Rigidbody2D>();
    }

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
        Debug.Log("Ball collission trigger");
        if (collision.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
