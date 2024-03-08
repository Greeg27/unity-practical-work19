using UnityEngine;

public class GotHitAnimationScript : MonoBehaviour
{
    private Animator Animator;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            Animator.SetTrigger("GotHitTrigger");
        }
    }
}
