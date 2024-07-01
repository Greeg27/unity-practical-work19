using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] Animator animator;
    [SerializeField] GameObject obj;
    [SerializeField] GameManagerScript gameManagerScript;
    private float health;

    private void Awake()
    {
        health = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        gameManagerScript.Score—alculation(damage);
        CheckAlive();
    }

    private void CheckAlive()
    {
        if (health <= 0)
        {
            obj.SetActive(false);
            animator.SetBool("JumpTrigger", true);
        }
    }

}
