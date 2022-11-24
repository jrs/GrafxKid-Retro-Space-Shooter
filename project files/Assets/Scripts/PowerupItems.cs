using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupItems : MonoBehaviour
{
    [SerializeField] int _value = 1;
    [SerializeField] float _moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime);
    }
}
