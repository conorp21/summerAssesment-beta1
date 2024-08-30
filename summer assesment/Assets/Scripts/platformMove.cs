using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    public float moveSpeed = 3f; 
    public float moveDistance = 2f;
    private bool moveRight = true;

    private Vector3 startPos; 

    void Start()
    {
        startPos = transform.position; 
    }

    void Update()
    {
        
        Vector3 moveDirection = moveRight ? Vector3.up : Vector3.down;

      
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

      
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
          
            moveRight = !moveRight;
        }
    }
}