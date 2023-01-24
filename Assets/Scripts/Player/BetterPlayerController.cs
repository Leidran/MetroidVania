using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterPlayerController : MonoBehaviour
{
    //Estats de moviment
    bool dashing = false;
    bool jumpCapable = false;

    //Stats basis del jugador
    float defaultSpeedMultiplier = 1f; //El multiplicador per defecte quan el jugador nomes es mou
    float dashSpeedMultiplier = 3f; //Repla�a la velocitat del jugador per defecte per aquest multiplicador quan el jugador utilitza l'abilitat Dash
    float speedMultiplier = 1f;
    float horizontalVel = 2f;
    float jumpPower = 5f;

    Vector2 inputForce = Vector2.zero; //Variable dedicada a darle velocidad al jugador a partir de los inputs, ejemplo en Movement()
    Vector3 feetPosition; //Posicion donde se enquentran los "pies" del jugador, teniendo en quenta que el jugador se encuntra en el centro de la escena, obviamente. Necesita ser Vector3 para sumarlo con transform.position

    Rigidbody2D rb2D;
    Collider2D coll2D;
    [SerializeField] LayerMask floorLayers;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<Collider2D>();
        feetPosition = new Vector3(0, coll2D.bounds.size.y * -0.5f, 0);
    }

    void Update()
    {
        StateChecker();
        Movement();
    }

    //Funcions per a si mateix
    void Movement()
    {
        //Horizontal
        inputForce.x = Input.GetAxisRaw("Horizontal") * (horizontalVel * speedMultiplier);
        
        //Vertical
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCapable)
            {
                inputForce.y = jumpPower;
            }
        }
        else
        {
            inputForce.y = rb2D.velocity.y;
        }

        rb2D.velocity = inputForce;
    }

    void StateChecker() //Dedicat a modificar el speedMultiplier depenent de quin estat(s) el jugador es troba
    {
        //jumpCapable check
        RaycastHit2D hit2D = Physics2D.BoxCast(transform.position + feetPosition, new Vector2(coll2D.bounds.size.x, 0.1f), 0f, Vector2.down, 0.1f, floorLayers);
        jumpCapable = hit2D;

        //dash check, si el jugador no esta en l'aire, independenment de si esta fent un dash, la seva velocitat incrementada es mantindra
        if (jumpCapable)
        {
            speedMultiplier = dashing ? dashSpeedMultiplier : defaultSpeedMultiplier;
        }
        
    }

    //Funcions publiques per a cridar desde altres scripts
    public void modifyDashState(bool state)
    { 
        dashing = state;
    }

    //Implementations
    public object SaveState()
    {
        return new SaveData()
        {
            xAxis = transform.position.x,
            yAxis = transform.position.y
        };
    }

    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        transform.position = new Vector2(saveData.xAxis, saveData.yAxis);
    }

    [Serializable]
    private struct SaveData
    {
        public float xAxis;
        public float yAxis;
    }
}