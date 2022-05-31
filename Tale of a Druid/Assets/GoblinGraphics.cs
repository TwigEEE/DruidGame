using UnityEngine;
using Pathfinding;

public class GoblinGraphics : MonoBehaviour
{
    
    public AIPath aiPath;
    public SpriteRenderer enemySpriteRenderer;
    public Animator enemyAnimator, scimitarAnimator;

    public Rigidbody2D enemyRigidbody;
    public CircleCollider2D enemyCollider;
    public LayerMask tileLayerMask;
    public PlayerStats playerStats;

    private bool jumping;
    public float jumpMultiplier;


    void Start()
    {
        jumping = false;
        
        jumpMultiplier = (playerStats.GetStat("strength") * 1.3f) + 8f;
    }


    // Update is called once per frame
    void Update()
    {
       
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            enemySpriteRenderer.flipX = false;
            enemyAnimator.SetBool("running", true);
            scimitarAnimator.SetBool("running", true);
            //SetColliders("running");
        }

        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            enemySpriteRenderer.flipX = true;
            enemyAnimator.SetBool("running", true);
            scimitarAnimator.SetBool("running", true);
            //SetColliders("running");
        }

        else
        {
            enemyAnimator.SetBool("running", false);
            scimitarAnimator.SetBool("running", false);     
        }

        if (IsGrounded())
        {
            jumping = false;
        }

        //Debug.Log("Velovity: " + enemyRigidbody.velocity);
        if(shouldJump())
        {
            if(! jumping)
            {
                enemyRigidbody.velocity = Vector2.up * jumpMultiplier * 100;
                jumping = true;
            }
        }
    }

    private bool shouldJump()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            RaycastHit2D raycastHit2D = Physics2D.BoxCast(enemyCollider.bounds.center, enemyCollider.bounds.size, 0f, Vector2.right, 0.5f, tileLayerMask);
            return raycastHit2D.collider != null;
        }

        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
           RaycastHit2D raycastHit2D = Physics2D.BoxCast(enemyCollider.bounds.center, enemyCollider.bounds.size, 0f, Vector2.left, 0.5f, tileLayerMask);
           return raycastHit2D.collider != null;
        }

        return false;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(enemyCollider.bounds.center, enemyCollider.bounds.size, 0f, Vector2.down, 0.2f, tileLayerMask);
        return raycastHit2D.collider != null;
    }

    
}
