using UnityEngine;

public class NavySealScript : MonoBehaviour
{
    [SerializeField] GameObject go;
    [SerializeField] int force;
    private Rigidbody2D rb;
    private bool flag = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage") && flag)
        {
            if (go.activeSelf == false)
            {
                rb.AddForce(new Vector2(transform.localScale.x, 0) * force);
                flag = false;
            }
        }
    }
}
