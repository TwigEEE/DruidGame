using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // --- Variables --- \\
    public float speed, jumpMultiplier;
    public bool jump, jumping, running;
    private string moveType;

    public Animator playerAnimator, scimitarAnimator;
    public CircleCollider2D playerHeadCollider;
    public CapsuleCollider2D playerBodyCollider;
    public Transform playerTransform;
    public Rigidbody2D playerRigidbody;
    public SpriteRenderer playerSpriteRenderer;
    public LayerMask tileLayerMask;
    public PlayerStats playerStats;


    // --- Start Function --- \\
    private void Start()
    {
        jump = false;
        jumping = false;
        running = false;
        
        speed = (playerStats.GetStat("dexterity") * 0.1f) + 0.1f;
        jumpMultiplier = (playerStats.GetStat("strength") * 1.3f) + 8f;
    }

    // --- Update Function --- \\
    private void Update()
    {   
        if (IsGrounded())
        {
            jumping = false;
        }

        GetMoveType();
    }


    // --- Fixed Update Function --- \\
    private void FixedUpdate()
    {
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
            SetColliders("idle");
        }

        if (jump)
        {
            playerRigidbody.velocity = Vector2.up * jumpMultiplier;
            jump = false;
            jumping = true;
        }
    }


    // --- Function To Get Player Input For Movement --- \\
    public void GetMoveType()
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


    // --- Function To Set The Player's Colliders --- \\
    private void SetColliders(string type)
    {
        if (type == "idle")
        {
            if (! playerSpriteRenderer.flipX)
            {
                playerBodyCollider.offset = new Vector2(0.25f, -0.76f);
                playerBodyCollider.size = new Vector2(5f, 11f);
                playerHeadCollider.offset = new Vector2(0.2f, 1.7f);
            }

            else if (playerSpriteRenderer.flipX)
            {
                playerBodyCollider.offset = new Vector2(-0.25f, -0.76f);
                playerBodyCollider.size = new Vector2(5f, 11f);
                playerHeadCollider.offset = new Vector2(-0.2f, 1.7f);
            }
        }
        
        else if (type == "running")
        {
            if (! playerSpriteRenderer.flipX)
            {
                playerBodyCollider.offset = new Vector2(1.7f, -3.36f);
                playerBodyCollider.size = new Vector2(5f, 5.8f);
                playerHeadCollider.offset = new Vector2(2.8f, 0.8f);
            }

            else if (playerSpriteRenderer.flipX)
            {
                playerBodyCollider.offset = new Vector2(-1.7f, -3.36f);
                playerBodyCollider.size = new Vector2(5f, 5.8f);
                playerHeadCollider.offset = new Vector2(-2.8f, 0.8f);
            }
        }
    }


    // --- Function To Check If Player Is Touching The Ground --- \\
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(playerBodyCollider.bounds.center, playerBodyCollider.bounds.size, 0f, Vector2.down, 0.2f, tileLayerMask);
        return raycastHit2D.collider != null;
    }
}
