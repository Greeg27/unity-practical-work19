using Unity.Mathematics;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] CanvasScript canvas;
    private float health;
    private float velocity;
    private Rigidbody2D rb;

    private void Awake()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        velocity = 0;
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > velocity) 
        { 
            velocity = rb.velocity.magnitude;
        }
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        canvas.PlayerHealthDisplay(health / maxHealth);
        CheckAlive();
    }

    private void CheckAlive()
    {
        if (health <= 0)
        {
            canvas.DeathPanelSetActiv();
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            TakeDamage(collision.gameObject.GetComponent<DamageDeallerScript>().Damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (velocity > 10)
        {
            int j = (int)velocity - 8;

            for (int i = 1; i < j; i++)
            {
                velocity *= 1.9f;
            }
            TakeDamage(math.abs(velocity));
        }

        velocity = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        velocity = 0;
    }


}
