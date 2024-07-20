using UnityEngine;

public class BonusPictureScript : MonoBehaviour
{
    [SerializeField] GameManagerScript gameManagerScript;
    private Animator anim;
    private bool firstTouch;

    private void Awake()
    {
        firstTouch = true;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (firstTouch && collision.CompareTag("Catches"))
        {
            firstTouch = false;
            gameManagerScript.Score—alculation(50);
            anim.SetBool("Play", true);
        }
    }
}
