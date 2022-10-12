using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _xRange = 8;
    [SerializeField] float _yRange = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
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
    }
}
