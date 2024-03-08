using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(DamageDeallerScript))]

public class BulletScript : MonoBehaviour
{
    [SerializeField] float lifeTime;

    private Rigidbody2D rb;
    private DamageDeallerScript dDS;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dDS = GetComponent<DamageDeallerScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dDS.Damage = Math.Abs(rb.velocity.x) + Math.Abs(rb.velocity.y);
        StartCoroutine(EndLifeTime());
    }

    IEnumerator EndLifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
