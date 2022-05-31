using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth = 100;

   
    private int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamge(int damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " took " + damage + " damage!!");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die() 
    {
        Debug.Log("died");
    }
}
