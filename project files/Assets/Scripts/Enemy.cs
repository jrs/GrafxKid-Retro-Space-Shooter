using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1;
    [SerializeField] int _health = 3;
    [SerializeField] int _value = 10;
    public GameObject EnemyProjectile;
    public GameObject ExplosionFX;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //InvokeRepeating("FireProjectile", 0.5f, 2);
        StartCoroutine(FireProjectile());
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.IsGameAcitve())
            transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime);
    }

    //void FireProjectile()
    //{
    //    Instantiate(EnemyProjectile, transform.position, EnemyProjectile.transform.rotation);
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            if (_health > 1)
            {
                _health--;
            }

            else
            {
                _gameManager.UpdateScore(_value);
                Destroy(this.gameObject);
            }
        }

        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(ExplosionFX, other.transform.position, ExplosionFX.transform.rotation);
        }

    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    IEnumerator FireProjectile()
    {
        float delayTime = Random.Range(0, 3);
        int spawnRate = Random.Range(0, 4);

        yield return new WaitForSeconds(0.5f);

        for(int i = 0; i < spawnRate; i++)
        {
            Instantiate(EnemyProjectile, transform.position, EnemyProjectile.transform.rotation);
            yield return new WaitForSeconds(delayTime);
        }
    }
}
