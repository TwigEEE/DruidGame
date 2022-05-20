using System;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed, jumpMultiplier;
    public bool jump, jumping, running;


    public Animator playerAnimator, scimitarAnimator;
    public CircleCollider2D playerHeadCollider;
    public CapsuleCollider2D playerBodyCollider;
    public Transform playerTransform;
    public Rigidbody2D playerRigidbody;
    public SpriteRenderer playerSpriteRenderer;
    public LayerMask tileLayerMask;

    public playerStats playerStats;

    private string moveType;

    void Start()
    {
        jump = false;
        jumping = false;
        running = false;
        
        speed = (playerStats.getStat("dexterity") * 0.01f) + 0.05f;
        jumpMultiplier = (playerStats.getStat("strength") * 0.25f) + 5;
    }


    void Update()
    {   
        
        if (IsGrounded())
        {
            jumping = false;
        }

        getMoveType();


    }


    void FixedUpdate()
    {

        SetColliders("idle");

        if (moveType == "right")
        {
            playerTransform.position = playerTransform.position + new Vector3(speed, 0, 0);
            playerSpriteRenderer.flipX = false;
            playerAnimator.SetBool("running", true);
            scimitarAnimator.SetBool("running", true);
            SetColliders("running");
        }

        else if (moveType == "left")
        {
            playerTransform.position = playerTransform.position + new Vector3(speed * -1, 0, 0);
            playerSpriteRenderer.flipX = true;
            playerAnimator.SetBool("running", true);
            scimitarAnimator.SetBool("running", true);
            SetColliders("running");
        }

        else 
        {
            playerAnimator.SetBool("running", false);
            scimitarAnimator.SetBool("running", false);
        }


        if (jump)
        {
            playerRigidbody.velocity = Vector2.up * jumpMultiplier;
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
            if (! playerSpriteRenderer.flipX)
            {
                playerBodyCollider.offset = new Vector2(0.25f, -0.76f);
                playerBodyCollider.size = new Vector2(5f, 11f);
                playerHeadCollider.offset = new Vector2(0.2f, 1.7f);
                playerHeadCollider.radius = 3f;
            }

            else if (playerSpriteRenderer.flipX)
            {
                playerBodyCollider.offset = new Vector2(-0.25f, -0.76f);
                playerBodyCollider.size = new Vector2(5f, 11f);
                playerHeadCollider.offset = new Vector2(-0.2f, 1.7f);
                playerHeadCollider.radius = 3f;
            }
        }
        
        else if (type == "running")
        {
            if (! playerSpriteRenderer.flipX)
            {
                playerBodyCollider.offset = new Vector2(1.7f, -3.36f);
                playerBodyCollider.size = new Vector2(5f, 5.8f);
                playerHeadCollider.offset = new Vector2(2.8f, 0.8f);
                playerHeadCollider.radius = 3f;
            }

            else if (playerSpriteRenderer.flipX)
            {
                playerBodyCollider.offset = new Vector2(-1.7f, -3.36f);
                playerBodyCollider.size = new Vector2(5f, 5.8f);
                playerHeadCollider.offset = new Vector2(-2.8f, 0.8f);
                playerHeadCollider.radius = 3f;
            }
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(playerBodyCollider.bounds.center, playerBodyCollider.bounds.size, 0f, Vector2.down, 0.1f, tileLayerMask);
        return raycastHit2D.collider != null;
    }
}
