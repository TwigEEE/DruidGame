using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    private bool jumping;
    public float jumpMultiplier;

    //public AIPath aiPath;
/*
    public Rigidbody2D enemyRigidbody;
    public CircleCollider2D enemyCollider;
    public LayerMask tileLayerMask;
    public PlayerStats playerStats;


    // Start is called before the first frame update
    void Start()
    {
        jumping = false;
        
        jumpMultiplier = (playerStats.GetStat("strength") * 1.3f) + 8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            jumping = false;
        }

        if(shouldJump)
        {
            if(! jumping)
            {
                enemyRigidbody.velocity = Vector2.up * jumpMultiplier;
                jumping = true;
            }
        }
    }

    private bool shouldJump()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            RaycastHit2D raycastHit2D = Physics2D.BoxCast(enemyCollider.bounds.center, enemyCollider.bounds.size, 0f, Vector2.right, 0.2f, tileLayerMask);
        }

        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
           RaycastHit2D raycastHit2D = Physics2D.BoxCast(enemyCollider.bounds.center, enemyCollider.bounds.size, 0f, Vector2.left, 0.2f, tileLayerMask);
        }

        else
        {
            return false;
        }

        return raycastHit2D.collider != null;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(enemyCollider.bounds.center, enemyCollider.bounds.size, 0f, Vector2.down, 0.2f, tileLayerMask);
        return raycastHit2D.collider != null;
    }
    */
}
