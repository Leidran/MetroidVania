using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject player1;
    public Vector2 minimum;
    public Vector2 maximum;
    public float smoothing;
    Vector2 velocicty;

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player1.transform.position.x, ref velocicty.x, smoothing);
        float posY = Mathf.SmoothDamp(transform.position.y, player1.transform.position.x, ref velocicty.y, smoothing);

        transform.position = new Vector3(Mathf.Clamp(posX, minimum.x, maximum.x), Mathf.Clamp(posY, minimum.y, maximum.y), transform.position.z);
    }
}
