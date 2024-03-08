using UnityEngine;

public class CableRollerScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] PlayerMovementScript PMS;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PMS.AdditionalSpeed = rb.velocity.x;
        }
    }
}
