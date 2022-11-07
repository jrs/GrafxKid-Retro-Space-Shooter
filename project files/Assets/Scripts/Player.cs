using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform FirePoint;
    public Animator PlayerBooter;
    public GameObject ProjectilePrefab;
    public GameObject ExplosionPrefab;
    public bool PlayerCanMove;
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] int _playerHealth = 10;

        
    private float _xRange = 8;
    private float _yRange = 4;
    private Animator _playerAnim;
    private Vector2 target;
    private Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //float step = 1f * Time.deltaTime;
        PlayerCanMove = true;
        //transform.position = Vector2.MoveTowards(transform.position, target, step);
        //if(transform.position.y == 0)
        //{
        //    PlayerCanMove = true;
        //}
        Movement();
        FireShot();
    } 

    private void Movement()
    {
        if(PlayerCanMove)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            Vector2 direction = new Vector2(horizontalInput, verticalInput);

            transform.Translate(direction * _moveSpeed * Time.deltaTime);
            
            if(transform.position.x < -_xRange)
            {
                transform.position = new Vector2(-_xRange, transform.position.y);
            }

            if(transform.position.x > _xRange)
            {
                transform.position = new Vector2(_xRange, transform.position.y);
            }

            if(transform.position.y < -_yRange)
            {
                transform.position = new Vector2(transform.position.x, -_yRange);
            }

            if(transform.position.y > _yRange)
            {
                transform.position = new Vector2(transform.position.x, _yRange);
            }

            if (horizontalInput > 0)
            {
                _playerAnim.SetInteger("TurnDirection", 1);
                PlayerBooter.SetInteger("BoostDirection", 1);
            }
            else if (horizontalInput < 0)
            {
                _playerAnim.SetInteger("TurnDirection", -1);
                PlayerBooter.SetInteger("BoostDirection", -1);
            }
            else
            {
                _playerAnim.SetInteger("TurnDirection", 0);
                PlayerBooter.SetInteger("BoostDirection", 0);
            }
        }

    }

    private void FireShot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(ProjectilePrefab, FirePoint.transform.position, ProjectilePrefab.transform.rotation);
        }
    }

    public void UpdatePlayerHealth(int amount)
    {
        if(_playerHealth > 0)
        {
            _playerHealth-= amount;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation);
            UpdatePlayerHealth(1);
        }

        if(other.CompareTag("Enemy Projectile"))
        {
            Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation);
            UpdatePlayerHealth(1);
            Destroy(other.gameObject);
        }
    }

}
