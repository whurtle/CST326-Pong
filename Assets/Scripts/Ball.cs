using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Score scoreManager;

    private Rigidbody rb;
    private float speedMultiplier = 1;
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = (int)Random.value * 2 - 1;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(direction, 0, 0) * this.speedMultiplier * 50);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (this.rb.velocity.x > 0)
        {
            this.rb.AddForce(new Vector3(0.5f, 0, 0) * speedMultiplier / 5);
        }
        else
        {
            this.rb.AddForce(new Vector3(-0.5f, 0, 0) * speedMultiplier / 5);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var collisionName = collision.gameObject.name;
        if (collisionName.Contains("Paddle"))
        {
            PaddleCollision(collision);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Goal"))
        {
            GoalCollision(other);
        }
    }


    private void PaddleCollision(Collision collision)
    {
        var ballZ = this.gameObject.transform.position.z;
        var paddleZ = collision.transform.position.z;

        if (ballZ < paddleZ)
        {
            rb.AddForce(new Vector3(0, 0, Mathf.Abs(paddleZ - ballZ)) * 10);
        }
        else if (ballZ > paddleZ)
        {
            rb.AddForce(new Vector3(0, 0, -1 * Mathf.Abs(paddleZ - ballZ)) * 10);
        }
    }

    private void GoalCollision(Collider other)
    {
        bool win;
        if (other.gameObject.name.Contains("Left"))
        {
            win = scoreManager.RightScored();
            this.direction = -1;
        } else
        {
            win = scoreManager.LeftScored();
            this.direction = 1;
        }
        this.resetBall();
        if(!win)
        {
            this.incrementSpeed();
        } else
        {
            this.speedMultiplier = 1;
        }
    }

    private void resetBall()
    {
        this.gameObject.transform.position = new Vector3(0, 0.5f, 0);
        this.rb.velocity = new Vector3(direction, 0, 0);
    }

    private void incrementSpeed()
    {
        this.speedMultiplier++;
    }
}
