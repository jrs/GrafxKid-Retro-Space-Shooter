using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 3;
    public GameObject EnemyProjectile;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireProjectile", 0.5f, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FireProjectile()
    {
        Instantiate(EnemyProjectile, transform.position, EnemyProjectile.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            if (Health > 1)
            {
                Destroy(other.gameObject);
                Health--;
            }

            else
            {
                Destroy(this.gameObject);
            }
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
