using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Config")]
    public Transform FirePoint;
    public Animator PlayerBooter;
    public GameObject ProjectilePrefab;
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _laserShot, _armorOn, _powerPickup;

    private float _xRange = 8;
    private float _yRange = 4;
    private Animator _playerAnim;
    private GameManager _gameManager;

    private float _coolDownTimer = 0;
    private float _waitTimer = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        PlayerBooter.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_coolDownTimer > 0)
        {
            _coolDownTimer -= Time.deltaTime;
        }

        if(_gameManager.IsGameAcitve())
        {
            PlayerBooter.enabled = true;
            Movement();
            FireShot();
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(horizontalInput, verticalInput);

        transform.Translate(direction * _moveSpeed * Time.deltaTime);

        if (transform.position.x < -_xRange)
        {
            transform.position = new Vector2(-_xRange, transform.position.y);
        }

        if (transform.position.x > _xRange)
        {
            transform.position = new Vector2(_xRange, transform.position.y);
        }

        if (transform.position.y < -_yRange)
        {
            transform.position = new Vector2(transform.position.x, -_yRange);
        }

        if (transform.position.y > _yRange)
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
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            Instantiate(ProjectilePrefab, FirePoint.transform.position, ProjectilePrefab.transform.rotation);
            _audioSource.PlayOneShot(_laserShot);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(_coolDownTimer <= 0)
        {
            if(other.CompareTag("Enemy") || other.CompareTag("Enemy Projectile"))
            {
                _gameManager.UpdatePlayerLives(1);
                _coolDownTimer = _waitTimer;
            }
        }

        if(other.gameObject.CompareTag("Power"))
        {
            _gameManager.UpdatePlayerPower(1);
            _audioSource.PlayOneShot(_powerPickup);
            Destroy(other.gameObject);
        }
    }
}
