using UnityEngine;

public class BonusPictureScript : MonoBehaviour
{
    [SerializeField] GameManagerScript gameManagerScript;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Catches"))
        {
            gameManagerScript.Score—alculation(50);
            anim.SetBool("Play", true);
        }
    }
}
