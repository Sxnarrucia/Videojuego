using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{

    public float horizontalSpeed = 7f;
    public float jumpSpeed = 50f; 

    private float horizontalMove;
    private bool lookright = true;

    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();



    }

    // Update is called once per frame
    void Update() 
    {
        ChangeDirection(horizontalMove);
        
    }

    private void FixedUpdate()
    {
        horizontalMove = Input.GetAxis("Horizontal"); 

        if(GroundCheck.checkCollision) rb.velocity = new Vector2(horizontalSpeed * horizontalMove , 0f);

        if(Input.GetKey(KeyCode.Space) && GroundCheck.checkCollision){

            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

        }


    }

    public void ChangeDirection(float h)
{
    if ((h > 0 && !lookright) || (h < 0 && lookright))
    {
        lookright = !lookright;
        Vector3 giro = transform.localScale;
        giro.x *= -1; // Invierte la dirección
        transform.localScale = giro;
    }
}



}
