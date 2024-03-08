using System.Collections;
using UnityEngine;

public class LookAtPlayerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(UpdateIE(collision.gameObject.transform));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

    IEnumerator UpdateIE(Transform tansform)
    {
        do
        {
            yield return new WaitForFixedUpdate();

            if (tansform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        while (true);
    }
}
