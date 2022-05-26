using UnityEngine;

public class EnemyScimitarFunctionallity : MonoBehaviour
{
    
    // --- Variables --- \\
    private float timePassedSinceAttack = 10;
    private bool attacking;
    private int damage, attackMultiplier;
    
    public Animator scimitarAnimator;
    public SpriteRenderer scimitarSpriteRenderer, enemySpriteRenderer;
    public Transform scimitarTransform, enemyTransform, attackPoint;
    public float attackRange;
    public LayerMask playerLayers;
    public PlayerStats playerStats;


    // --- Update Function --- \\
    void Update()
    {
        timePassedSinceAttack += Time.deltaTime;
        
        SetScimitarAndAttackPoint();

        if(CheckIfPlayerInRange())
        {
            if (timePassedSinceAttack > 1)
            {
                Attack();
                timePassedSinceAttack = 0;
            }
        }
    }

    
    // --- Function To Make Player Attack --- \\
    private void Attack()
    {
        attacking = true;
        
        if (! scimitarSpriteRenderer.flipX)
        { 
            scimitarTransform.position = enemyTransform.position + new Vector3(0.3f, 0, 0);
        }
        
        else
        {
            scimitarTransform.position = enemyTransform.position + new Vector3(-0.3f, 0, 0);
        }
        
        scimitarAnimator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            if (playerStats.GetStat("strength") > playerStats.GetStat("dexterity"))
            {
                attackMultiplier = playerStats.GetModifier("strength");
            }
            
            else
            {
                attackMultiplier = playerStats.GetModifier("dexterity");
            }

            damage = Random.Range(1, 7) + attackMultiplier;
            enemy.GetComponent<Health>().TakeDamge(damage);
        }
    }

    
    // --- Function To Set The Positions Of The Scimitar And Attack Point --- \\
    private void SetScimitarAndAttackPoint()
    {
        if (! attacking)
        {    
            scimitarSpriteRenderer.flipX = enemySpriteRenderer.flipX;
            
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
            scimitarTransform.position = enemyTransform.position + new Vector3(0, 0, 0);
        }
    }

    private bool CheckIfPlayerInRange()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            return true;
        }
            
        return false;
    }
}

/*
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
*/

