using System.Collections;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform FirePoint;
    [SerializeField] Transform FireBreech;
    [SerializeField] float fireSpeed;

    public void ShootingStart()
    {
        StartCoroutine(Shooting());
    }

    public void ShootingStop()
    {
        StopAllCoroutines();
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(0.15f);
        }
    }

    private void Shoot()
    {
        GameObject currentBullet = Instantiate(Bullet, FirePoint.position, Quaternion.identity);
        Rigidbody2D rb = currentBullet.GetComponent<Rigidbody2D>();
        rb.velocity = (FirePoint.position - FireBreech.position).normalized * fireSpeed;
    }
}
