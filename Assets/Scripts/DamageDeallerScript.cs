using UnityEngine;

public class DamageDeallerScript : MonoBehaviour
{
    public float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            collision.gameObject.GetComponent<HealthScript>().TakeDamage(Damage);
        }
    }
}
