using System.Collections;
using UnityEngine;

public class Cabin : MonoBehaviour
{
    [SerializeField] GameObject enemie;
    [SerializeField] int quantity;

    public void EnemiesSpawner()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        for (int i = 0; i < quantity; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(enemie, transform.position, Quaternion.identity);
        }
        StopAllCoroutines();
    }
}
