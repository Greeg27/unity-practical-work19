using UnityEngine;

public class AtackAnimationScript : MonoBehaviour
{
    private Animator Animator;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Animator.SetBool("StaticEnemie1Bool", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Animator.SetBool("StaticEnemie1Bool", false);
    }

}
