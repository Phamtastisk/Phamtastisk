using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode Jump;

    private Rigidbody2D rb2d; //Refererer til spillerens rigidbody så man kan intagerer med den

    public Transform groundCheck;
    public bool isGrounded; //Checker om han rammer jorden
    public float groundCheckradius; //GroundCheck som er under spilleren
    public LayerMask WhatisGround;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //Når den starter spillet finder den rigidbody som er vedhæftet til spilleren.
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckradius, WhatisGround);

        if (Input.GetKey(left))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y); // Reagerer når man går til venstre, og derfår går i minus på Scale
        }
        else if (Input.GetKey(right))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);// Reagerer når man går til højre
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y); // Når man  hverken trykker på højre eller venstre betyder det at den skal stoppe. 
        }

        if (Input.GetKeyDown(Jump) && isGrounded) //Checker om det lige er trykket og ikke holdt nede. Og om IsGrounded er sandt.
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) //Tjekker om mit gameobject rammer "Enemy"
        {
            Application.LoadLevel(Application.loadedLevel); //Genstarter efter død.
        }
       
    }
}