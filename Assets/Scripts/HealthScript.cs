using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] Animator animator;
    [SerializeField] GameObject obj;
    private float health;

    private void Awake()
    {
        health = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            TakeDamage(collision.gameObject.GetComponent<DamageDeallerScript>().Damage);
        }
    }


}
