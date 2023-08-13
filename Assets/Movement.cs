using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");



    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * 10, rb.velocity.y);
    }



}
