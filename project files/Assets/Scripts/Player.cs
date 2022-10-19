using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform FirePoint;

    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _xRange = 8;
    [SerializeField] float _yRange = 4;
    [SerializeField] GameObject _projectilePrefab;
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

    void FixedUpdate()
    {
        
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * horizontalInput * _moveSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * verticalInput * _moveSpeed * Time.deltaTime);

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

        if(horizontalInput > 0)
        {
            _playerAnim.SetInteger("TurnDirection", 1);
        }
        else if(horizontalInput < 0)
        {
            _playerAnim.SetInteger("TurnDirection", -1);
        }
        else{
            _playerAnim.SetInteger("TurnDirection", 0);
        }
    }

    private void FireShot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(_projectilePrefab, FirePoint.transform.position, _projectilePrefab.transform.rotation);
        }
    }
}
