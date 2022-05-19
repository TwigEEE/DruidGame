using UnityEngine;

public class ScimitarFunctionallity : MonoBehaviour
{
    
    public Animator scimitarAnimator;
    public SpriteRenderer scimitarSpriteRenderer, playerSpriteRenderer;
    public Transform scimitarTransform, playerTransform, attackPoint;
    public float attackRange = 2.5f;
    public LayerMask enemyLayers;
    
    private float timePassedSinceAttack = 10;




    // Update is called once per frame
    void Update()
    {

        follow();

        timePassedSinceAttack += Time.deltaTime;


        if(Input.GetKey("space"))
        {
            if (timePassedSinceAttack > 1)
            {
                attack();
                timePassedSinceAttack = 0;
            }
        }

    }

    void attack()
    {

        scimitarAnimator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " took 24 damage");
            enemy.GetComponent<Health>().TakeDamge(24);
        }
    }

/*
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
*/


    void follow()
    {
        scimitarTransform.position = playerTransform.position;
        scimitarSpriteRenderer.flipX = playerSpriteRenderer.flipX;

        if (! scimitarSpriteRenderer.flipX)
        {
            attackPoint.position = playerTransform.position + new Vector3(1f, 0, 0);
        }
        
        else
        {
            attackPoint.position = playerTransform.position + new Vector3(-1f, 0, 0);
        }
        
    }   
}
