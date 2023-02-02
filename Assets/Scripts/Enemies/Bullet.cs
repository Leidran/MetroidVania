using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    GameObject target;
    [SerializeField] private float speed;
    Vector2 targetPosition;

    private void Awake()
    {
        target = GameObject.Find("Player");
    }

    private void Start()
    {
        //keep Player 's initial position
        targetPosition = target.transform.position;
    }

    void Update()
    {
        // move to the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    // Destroy itself when It's out of the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
