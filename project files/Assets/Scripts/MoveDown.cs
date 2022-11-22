using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(_gameManager.IsGameAcitve())
            transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime);
    }
}
