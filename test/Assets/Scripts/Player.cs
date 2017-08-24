﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float jumpHeight = 100;
    public float moveSpeed = 5;
    public float speedLimit = 5;

    private short lettersCollected = 0;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void IsGameOver()
    {
        if (lettersCollected >= 6)
        {
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate ()
    {
        SpeedLimit();
        if (Input.GetKeyDown("up") && IsGrounded())
        {
            Jump();
        }
        if (Input.GetKey("left"))
        {
            Move("left");
            
        }
        if (Input.GetKey("right"))
        {
            Move("right");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("collectible"))
        {
            collision.gameObject.SetActive(false);
            lettersCollected++;
            IsGameOver();
        }
    }

    private void Jump()
    {
        Vector2 jumpVector = new Vector2(0, jumpHeight);
        rb2d.AddForce(jumpVector);
    }

    private void Move(string direction)
    {
        if (direction == "left")
        {
            if (IsGrounded()) rb2d.AddForce(new Vector2(-moveSpeed * 3, 0));
            else rb2d.AddForce(new Vector2(-moveSpeed * 1, 0));
            transform.Rotate(new Vector3(0, 0, 5) * (-rb2d.velocity.x));
        }
        else if(direction == "right")
        {
            if (IsGrounded()) rb2d.AddForce(new Vector2(moveSpeed * 3, 0));
            else rb2d.AddForce(new Vector2(moveSpeed * 1, 0));
            transform.Rotate(new Vector3(0, 0, 5) * (-rb2d.velocity.x));
        }
    }

    private void SpeedLimit()
    {
        if (rb2d.velocity.x > speedLimit) rb2d.velocity = new Vector2(speedLimit, rb2d.velocity.y);
        if (rb2d.velocity.x < -speedLimit) rb2d.velocity = new Vector2(-speedLimit, rb2d.velocity.y);
    }

    private bool IsGrounded()
    {
        if (rb2d.velocity.y == 0)
            return true;
        else return false;
    }
}
