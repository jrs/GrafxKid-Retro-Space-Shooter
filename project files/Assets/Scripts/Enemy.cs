using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MoveSpeed = 1;
    public int Damage = 1;
    public int Health = 3;
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Projectile") && Health > 1)
        {
            Destroy(other.gameObject);
            Health--;
        }
        else
        {
            Destroy(this.gameObject);
        }

        if(other.CompareTag("Player"))
        {
            _player.UpdatePlayerHealth(Damage);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
