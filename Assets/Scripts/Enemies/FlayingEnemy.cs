using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlayingEnemy : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float speed;
    [SerializeField] private GameObject target;
    [SerializeField] private float range;

    private void Awake()
    {
        //Retrive the game object where it 's name is Player
        target = GameObject.Find("Player");
    }

    void Update()
    {
        //measure the distance between the current player position and enemy positon
        distance = Vector2.Distance(transform.position, target.transform.position);
        
        if (distance<range)
        {
            //Follow the player
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
}
