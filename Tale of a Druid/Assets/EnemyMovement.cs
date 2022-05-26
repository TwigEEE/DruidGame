using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed, jumpMultiplier;
    public bool jump, jumping, running;
    private string moveType;

    public Animator enemyAnimator, scimitarAnimator;
    public CircleCollider2D enemyHeadCollider;
    public CapsuleCollider2D enemyBodyCollider;
    public Transform enemyTransform, playerTransform;
    public Rigidbody2D enemyRigidbody;
    public SpriteRenderer enemySpriteRenderer;
    public LayerMask tileLayerMask;
    public PlayerStats enemyStats;

    // Start is called before the first frame update
    void Start()
    {
        jump = false;
        jumping = false;
        running = false;
        
        speed = 0.05f;
        jumpMultiplier = 5f;
    }

    // Update is called once per frame
    void Update()
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
            enemyTransform.position = enemyTransform.position + new Vector3(speed, 0, 0);
            enemySpriteRenderer.flipX = false;
            enemyAnimator.SetBool("running", true);
            scimitarAnimator.SetBool("running", true);
            SetColliders("running");
        }

        else if (moveType == "left")
        {
            enemyTransform.position = enemyTransform.position + new Vector3(speed * -1, 0, 0);
            enemySpriteRenderer.flipX = true;
            enemyAnimator.SetBool("running", true);
            scimitarAnimator.SetBool("running", true);
            SetColliders("running");
        }

        else 
        {
            enemyAnimator.SetBool("running", false);
            scimitarAnimator.SetBool("running", false);
            SetColliders("idle");
        }

        if (jump)
        {
            enemyRigidbody.velocity = Vector2.up * jumpMultiplier;
            jump = false;
            jumping = true;
        }
    }




    public void GetMoveType()
    {
        if(playerTransform.position.x > enemyTransform.position.x) 
        {
            moveType = "right";
        }

        else if(playerTransform.position.x < enemyTransform.position.x) 
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
            if (! enemySpriteRenderer.flipX)
            {
                enemyBodyCollider.offset = new Vector2(0.25f, -0.76f);
                enemyBodyCollider.size = new Vector2(5f, 11f);
                enemyHeadCollider.offset = new Vector2(0.2f, 1.7f);
            }

            else if (enemySpriteRenderer.flipX)
            {
                enemyBodyCollider.offset = new Vector2(-0.25f, -0.76f);
                enemyBodyCollider.size = new Vector2(5f, 11f);
                enemyHeadCollider.offset = new Vector2(-0.2f, 1.7f);
            }
        }
        
        else if (type == "running")
        {
            if (! enemySpriteRenderer.flipX)
            {
                enemyBodyCollider.offset = new Vector2(1.7f, -3.36f);
                enemyBodyCollider.size = new Vector2(5f, 5.8f);
                enemyHeadCollider.offset = new Vector2(2.8f, 0.8f);
            }

            else if (enemySpriteRenderer.flipX)
            {
                enemyBodyCollider.offset = new Vector2(-1.7f, -3.36f);
                enemyBodyCollider.size = new Vector2(5f, 5.8f);
                enemyHeadCollider.offset = new Vector2(-2.8f, 0.8f);
            }
        }
    }


    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(enemyBodyCollider.bounds.center, enemyBodyCollider.bounds.size, 0f, Vector2.down, 0.2f, tileLayerMask);
        return raycastHit2D.collider != null;
    }
}
