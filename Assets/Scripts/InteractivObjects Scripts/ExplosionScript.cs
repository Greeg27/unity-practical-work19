using System.Collections;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] GameObject mankey;
    private Animator animator;
    private PointEffector2D pointEffector;
    private int collisionQuantity;

    void Start()
    {
        pointEffector = GetComponent<PointEffector2D>();
        animator = mankey.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionQuantity++;

        if (collisionQuantity == 100)
        {
            animator.SetTrigger("MankeyTrigger");
            StartCoroutine(Mankey());
        }
    }

    private IEnumerator Mankey()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(mankey);
        pointEffector.forceMagnitude = 50;
        StartCoroutine(DelExplosion());
    }

    private IEnumerator DelExplosion()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
