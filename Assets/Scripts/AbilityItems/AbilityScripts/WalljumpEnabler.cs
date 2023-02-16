using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalljumpEnabler : MonoBehaviour
{
    BoxCollider2D coll2D;
    Vector3 collBounds, boxPosLeft, boxPosRight;
    Rigidbody2D rb2D;
    Vector2 inputForce = Vector2.zero;
    [SerializeField]LayerMask floorLayer;

    void Start()
    {
        coll2D = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();

        collBounds = new Vector3(0.1f, coll2D.size.y, 0);
        boxPosLeft = new Vector3(coll2D.size.x * -0.5f, 0, 0);
        boxPosRight = new Vector3(coll2D.size.x * 0.5f, 0, 0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics2D.BoxCast(transform.position + boxPosLeft, collBounds, 0f, Vector2.left, 0f, floorLayer) ||
                Physics2D.BoxCast(transform.position + boxPosRight, collBounds, 0f, Vector2.right, 0f, floorLayer))
            {
                inputForce.y = 2f;
                inputForce.x = rb2D.velocity.x;

                rb2D.velocity = inputForce;
            }
        }
    }
}
