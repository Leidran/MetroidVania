using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalljumpEnabler : MonoBehaviour
{

    Collider2D coll2D;
    Rigidbody2D rb2D;

    void Start()
    {
        coll2D = GetComponent<Collider2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
    }
}
