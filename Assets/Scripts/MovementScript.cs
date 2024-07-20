using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementScript : MonoBehaviour
{
    [SerializeField] float normalSpeed;
    [SerializeField] SpriteRenderer sprite;
    private Rigidbody2D rb;
    private float curentSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        curentSpeed = normalSpeed;
    }

    private void HorizontalMovement(float speed)
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void Update()
    {
        HorizontalMovement(curentSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        curentSpeed *= -1;
        sprite.flipX = !sprite.flipX;
    }
}
