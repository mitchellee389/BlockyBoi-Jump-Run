using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 4.0f;
    public float jumpForce = 1000.0f;
    bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        /* CheckIfGrounded();*/
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor" || col.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
        if (col.gameObject.tag == "Coin")
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "Game")
            {
                SceneManager.LoadScene("Level 2");
            }
            else if (sceneName == "Level 2")
            {
                SceneManager.LoadScene("Level 3");
            }
            else if (sceneName == "Level 3")
            {
                SceneManager.LoadScene("WINNEY");
            }
        }
    }
}