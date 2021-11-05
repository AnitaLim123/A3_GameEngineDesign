using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private float dirX, dirZ;
    private float movespeed;
    public float jump;
    bool onGround = true;

    void Start()
    {
        jump = 5f;
        movespeed = 8f;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * movespeed;
        dirZ = Input.GetAxis("Vertical") * movespeed;

        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            //onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
        Debug.Log(collision.gameObject.tag);
    }

    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
        Debug.Log("boob");
        
        if (collision.gameObject.CompareTag("End"))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
    }
}