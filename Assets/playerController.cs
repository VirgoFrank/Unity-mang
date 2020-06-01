using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private enum State { idle, running, jumping, falling, hurt }
    private State state = State.idle;
    private Collider2D coll;

    [SerializeField]
    private LayerMask ground;
    [SerializeField]
    private LayerMask wall;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private int Cards = 0;
    [SerializeField]
    private Text CardsText;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
            Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Sõidukaart")
        {
            Destroy(collision.gameObject);
            Cards++;
            CardsText.text = Cards.ToString();
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jump")
        {
            rb.velocity = new Vector2(rb.velocity.x, 200);
        }
    }

    private void Movement()
    {
        float Hdirection = Input.GetAxis("Horizontal");
        if (coll.IsTouchingLayers(wall) && !coll.IsTouchingLayers(ground))
        {
            return;
        }
            
       
            if (Hdirection < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                transform.localScale = new Vector2(-1, 1);

            }
            else if (Hdirection > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                transform.localScale = new Vector2(1, 1);

            }
        
            if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                
            }
        
      
    }
}
