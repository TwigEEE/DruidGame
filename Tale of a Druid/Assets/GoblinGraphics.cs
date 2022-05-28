using UnityEngine;
using Pathfinding;

public class GoblinGraphics : MonoBehaviour
{
    
    public AIPath aiPath;
    public SpriteRenderer enemySpriteRenderer;
    public Animator enemyAnimator, scimitarAnimator;

    // Update is called once per frame
    void Update()
    {

        Debug.Log(aiPath.desiredVelocity.x);

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
    }

    
}
