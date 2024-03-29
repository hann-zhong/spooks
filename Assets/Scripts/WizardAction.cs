﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAction : MonoBehaviour
{
    public float speed = 2f;

    public Rigidbody2D rb;
    public Camera c;
    public GameObject gameOver;
    public GameObject restart;
    public GameObject ghost;
    Vector2 move;
    Vector2 mousePosition;
    Vector2 lookDirection;

    void Start()
    {
        //Prevent game over and restart from appearing on the screen at the start of the game
        gameOver.SetActive(false);
        restart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Controls movement with WASD and arrow keys
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        mousePosition = c.ScreenToWorldPoint(Input.mousePosition);

    }

    void FixedUpdate()
    {
        //Allows player to turn position the wizard's angle with the mouse
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        lookDirection = mousePosition - rb.position;

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the wizard collides with a Spook, game over and restart will appear, wizard will disappear, and Spooks will stop spawning
        if(collision.gameObject.tag.Equals("Enemy")){
            gameOver.SetActive(true);
            restart.SetActive(true);
            gameObject.SetActive(false);
            ghost.SetActive(false);
        }
    }
}
