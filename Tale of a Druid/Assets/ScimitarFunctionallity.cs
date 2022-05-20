using UnityEngine;

public class ScimitarFunctionallity : MonoBehaviour
{
    
    public Animator scimitarAnimator;
    public SpriteRenderer scimitarSpriteRenderer, playerSpriteRenderer;
    public Transform scimitarTransform, playerTransform, attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;

    public playerStats playerStats;
    
    private float timePassedSinceAttack = 10;
    private bool attacking;
    private int damage, attackMultiplier;


    // Update is called once per frame
    void Update()
    {
        timePassedSinceAttack += Time.deltaTime;
        
        setScimitarAndAttackPoint();

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
        attacking = true;
        
        if (! scimitarSpriteRenderer.flipX)
        { 
            scimitarTransform.position = playerTransform.position + new Vector3(0.3f, 0, 0);
        }
        else
        {
            scimitarTransform.position = playerTransform.position + new Vector3(-0.3f, 0, 0);
        }
        
        scimitarAnimator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            if (playerStats.getStat("strength") > playerStats.getStat("dexterity"))
            {
                attackMultiplier = playerStats.getModifier("strength");
            }
            else
            {
                attackMultiplier = playerStats.getModifier("dexterity");
            }

            damage = Random.Range(1, 7) + attackMultiplier;
            Debug.Log(enemy.name + " took " + damage + " damage");
            enemy.GetComponent<Health>().TakeDamge(damage);
        }
    }

    void setScimitarAndAttackPoint()
    {
        if (! attacking)
        {    
            scimitarSpriteRenderer.flipX = playerSpriteRenderer.flipX;
            
            if (! scimitarSpriteRenderer.flipX)
            {
                attackPoint.position = scimitarTransform.position + new Vector3(0.7f, 0, 0);
            }
            
            else 
            {
                attackPoint.position = scimitarTransform.position + new Vector3(-0.7f, 0, 0);
            }
        }

        if (timePassedSinceAttack > 0.45)
        {
            attacking = false;
            scimitarTransform.position = playerTransform.position + new Vector3(0, 0, 0);
        }
    }
}

/*
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
*/

