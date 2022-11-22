using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 10;
    public GameObject ExplosionFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Instantiate(ExplosionFX, transform.position, ExplosionFX.transform.rotation);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
