using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    [SerializeField] private LayerMask m_WhatIsEnemy;

    private Rigidbody rb;

    //private Collider sword;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x , 600, rb.velocity.z);
    }
}
