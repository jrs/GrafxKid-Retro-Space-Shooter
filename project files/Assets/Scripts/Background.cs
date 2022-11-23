using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] float _upperBounds = 11f;
    [SerializeField] float _lowerBounds = -22f;
    [SerializeField] float _moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime);

        if (transform.position.y < _lowerBounds)
        {
            transform.position = new Vector2(transform.position.x, _upperBounds);
        }
    }
}
