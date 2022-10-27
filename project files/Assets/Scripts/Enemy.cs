using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MoveSpeed = 1;
    public int Damage = 1;
    public int Health = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
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
