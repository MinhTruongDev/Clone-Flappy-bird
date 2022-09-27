using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody2D rb;
    GameObject gameController;
    [SerializeField] float jumpForce = 25f;
    [SerializeField] private float delayTime = 2f;
    [SerializeField] float mass = 5f;
    [SerializeField] float gravityScale = 15f;


    private void Start()
    {
        StartCoroutine(BeginGame());
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Jump();
        }
    }
    IEnumerator BeginGame()
    {
        //rb.bodyType is Kinematic right here
        rb = GetComponent<Rigidbody2D>();
        // jumpForce = 0 so the player don't make the bird move while waiting the coroutine
        jumpForce = 0;

        //change rigidbody2d.bodytype to Dynamic so the bird can be affect by gravity
        yield return new WaitForSeconds(delayTime);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.mass = mass;
        rb.gravityScale = gravityScale;
        jumpForce = 40f;
        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }

    }
    public void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<GameControl>().GetPoint();
    }


    void EndGame()
    {
        gameController.GetComponent<GameControl>().EndGame();
    }


   


}
