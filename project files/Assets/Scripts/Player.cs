using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform FirePoint;
    public Animator PlayerBooter;
    public GameObject ProjectilePrefab;
    public GameObject ExplosionPrefab;

    [SerializeField] float _moveSpeed = 5;
    [SerializeField] int _playerHealth = 10;
    
    private float _xRange = 8;
    private float _yRange = 4;
    private Animator _playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        FireShot();
    }

    private void Movement()
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
            Debug.Log("Player is out of health.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation);
            if(_playerHealth > 1)
            {
                UpdatePlayerHealth(1);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
