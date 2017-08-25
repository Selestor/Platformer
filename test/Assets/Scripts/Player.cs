using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float jumpHeight = 100;
    public float moveSpeed = 5;
    public float speedLimit = 5;

    public Text victoryText;
    public Text timeText;
    public GameObject menuPanel;
    public bool paused = false;

    private short lettersCollected = 0;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        victoryText.text = "";
        timeText.text = "Time left: 60" + " seconds!";
        Unpause();
    }

    private void Update()
    {
        float timeLeft = (Mathf.Round(60 - Time.timeSinceLevelLoad));
        timeText.text = "Time left: " + timeLeft  + " seconds!";
        if (timeLeft <= 0) GameOver("Time's up!");

        if (Input.GetKeyDown("escape"))
        {
            if (paused == true)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0.0f;
        timeText.text = Time.time.ToString();
        menuPanel.SetActive(true);
        paused = true;
    }

    private void Unpause()
    {
        Time.timeScale = 1.0f;
        menuPanel.SetActive(false);
        paused = false;
    }

    void IsGameOver()
    {
        if (lettersCollected >= 6)
        {
            GameOver("Your time: " + Time.timeSinceLevelLoad + " seconds!");
        }
    }

    void GameOver(string message)
    {
        gameObject.SetActive(false);
        victoryText.text = message;
        menuPanel.SetActive(true);
        SavePlayerPrefs();
    }

    private void SavePlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("Best Time"))
            PlayerPrefs.SetFloat("Best Time", Time.timeSinceLevelLoad);
        else
        {
            if (PlayerPrefs.GetFloat("Best Time") > Time.timeSinceLevelLoad)
                PlayerPrefs.SetFloat("Best Time", Time.timeSinceLevelLoad);
        }

        if (PlayerPrefs.HasKey("Games Played"))
            PlayerPrefs.SetInt("Games Played", PlayerPrefs.GetInt("Games Played") + 1);
        else PlayerPrefs.SetInt("Games Played", 1);
        PlayerPrefs.Save();
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
