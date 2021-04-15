using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    [SerializeField] private LayerMask m_WhatIsEnemy;
    [SerializeField] private LayerMask m_WhatIsGround;
    public float jumpforce = 10;
    public float raycastHeight = 1;

    bool hitDetected;
    public bool isGrounded;

    bool jumped;

    private Rigidbody rb;
    private Collider col;

    //private Collider sword;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        if (Input.GetKey(KeyCode.Space))
        {
            if (!jumped)
            {
                jumped = true;
                Jump();
                Invoke("resetJump", 2);
            }
            
        }
    }

    private void resetJump()
    {
        jumped = false;   
    }

    //private bool IsGrounded()
    //{
    //    if (rb.velocity.y <= 0)
    //    {
    //        //RaycastHit2D raycastHit = Physics2D.Raycast(m_BoxCollider2D.bounds.center, Vector2.down, m_BoxCollider2D.bounds.extents.y + extraHeight, m_WhatIsGround);
    //        hitDetected = Physics.BoxCast(col.bounds.center, col.bounds.size, Vector3.forward, transform.rotation, raycastHeight, m_WhatIsGround);

    //        Color rayColor;
    //        if (hitDetected)
    //        {
    //            rayColor = Color.green;
    //            isGrounded = true;
    //        }
    //        else
    //        {
    //            rayColor = Color.red;
    //            isGrounded = false;
    //        }
    //        //Debug.DrawRay(m_BoxCollider2D.bounds.center, Vector2.down * (m_BoxCollider2D.bounds.extents.y + extraHeight), rayColor);
    //        Debug.DrawRay(col.bounds.center - new Vector3(col.bounds.extents.x, col.bounds.extents.y), Vector2.right * (col.bounds.extents.y), rayColor);

    //        //Debug.Log(raycastHit.collider);
    //        return hitDetected;
    //    }
    //    else
    //    {
    //        return false;
    //    }

    //}

    private void Jump()
    {
        rb.AddForce(new Vector3(rb.velocity.x , jumpforce, rb.velocity.z));
    }
}
