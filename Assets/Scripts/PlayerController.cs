using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rb2D;
    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        
        moveSpeed = 1.5f;
        jumpForce = 10f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        //rtns [-1, 1] 
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical   = Input.GetAxisRaw("Vertical");
    }
    
    //update with physics
    void FixedUpdate()
    {   
        
        if((moveHorizontal > 0.1f) || (moveHorizontal < -0.1f) || (moveVertical > 0.1f))
        {
            Debug.Log("moveVertical + " + moveVertical +  " moveHori + " + moveHorizontal);
        }
        
        //we are moving right || left
        if((moveHorizontal > 0.1f) || (moveHorizontal < -0.1f))
        {
            //Force Vector <x,y> scaled by movespeed
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }
        
        //we are about to moving up
        if(!isJumping && (moveVertical > 0.1f))
        {
            //Force Vector <x,y> scaled by jumpForce
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
    }
    
    //called when entering collision with GameObject detected
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }
    
    //called when exiting collision
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}
