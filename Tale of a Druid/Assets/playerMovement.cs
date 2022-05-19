using System;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed, jumpMultiplier;
    public bool jump, jumping, running;


    public Animator playerAnimator;
    public Animator scimitarAnimator;
    public BoxCollider2D colliderIdle1, colliderIdle2, colliderRunning1;
    public CircleCollider2D colliderIdle3, colliderRunning2, colliderRunning3;
    public Transform transform;
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer SpriteRenderer;

    private string moveType;

    void Start()
    {
        jump = false;
        jumping = false;
        running = false;
    }


    void Update()
    {   
        jumping = false;
        getMoveType();


    }


    void FixedUpdate()
    {

        if (moveType == "right")
        {
            transform.position = transform.position + new Vector3(speed, 0, 0);
            SpriteRenderer.flipX = false;
            playerAnimator.SetBool("running", true);
            scimitarAnimator.SetBool("running", true);
        }

        else if (moveType == "left")
        {
            transform.position = transform.position + new Vector3(speed * -1, 0, 0);
            SpriteRenderer.flipX = true;
            playerAnimator.SetBool("running", true);
            scimitarAnimator.SetBool("running", true);
        }

        else 
        {
            playerAnimator.SetBool("running", false);
            scimitarAnimator.SetBool("running", false);
        }

        Debug.Log(jumping);
        if (jump)
        {
            rigidbody2D.AddForce(transform.up * jumpMultiplier, ForceMode2D.Impulse);
            jump = false;
            jumping = true;
        }
    }

    void getMoveType()
    {

        if(Input.GetKey("d")) 
        {
            moveType = "right";
        }

        else if(Input.GetKey("a")) 
        {
            moveType = "left";
        }

        else
        {
            moveType = "";
        }

        if(Input.GetKey("w") && ! jumping) 
        {
            jump = true;
        }
    }



    private void SetColliders(string type)
    {
        if (type == "idle")
        {
            colliderIdle1.enabled = true;
            colliderIdle2.enabled = true;
            colliderIdle3.enabled = true;
            colliderRunning1.enabled = false;
            colliderRunning2.enabled = false;
            colliderRunning3.enabled = false;
        }
        
        else if (type == "running")
        {
            colliderIdle1.enabled = false;
            colliderIdle2.enabled = false;
            colliderIdle3.enabled = false;
            colliderRunning1.enabled = true;
            colliderRunning2.enabled = true;
            colliderRunning3.enabled = true;
        }
    }
}