using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float MoveSpeed = 1;
    public float UpperBounds = 11f;
    public float LowerBounds = -22f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);

        if(transform.position.y < LowerBounds)
        {
            transform.position = new Vector2(transform.position.x, UpperBounds);
        }
    }
}
