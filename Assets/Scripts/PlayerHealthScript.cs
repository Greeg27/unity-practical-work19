using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] CanvasScript canvas;
    private float health;

    private void Awake()
    {
        health = maxHealth;
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
            Time.timeScale = 0f;
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
