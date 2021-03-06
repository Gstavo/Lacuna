﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 1;
	private bool isGrounded = true;
	private string anim = "Idle";
	bool isWalking = false;

	Animator animator;
	//animation states - the values in the animator conditions
	const int STATE_IDLE = 0;
	const int STATE_WALK = 1;

	int currentAnimationState = STATE_IDLE;
	string currentDirection = "left";


	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		

	}

	void FixedUpdate() {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		if (Input.GetKey("up") && isGrounded) {
			animator.SetInteger("state", STATE_IDLE);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 250));
			//animator.SetInteger("state", STATE_JUMP);
			isGrounded = false;
		}
		else if (Input.GetKey("right"))
		{
			animator.SetInteger("state", STATE_WALK);
			changeDirection("right");
			transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);

			if (this.currentAnimationState != STATE_WALK) {
				
				currentAnimationState = STATE_WALK;
			}
		}
		else if (Input.GetKey("left"))
		{
			
			animator.SetInteger("state", STATE_WALK);

			changeDirection("left");
			transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);

			if (this.currentAnimationState != STATE_IDLE)
			{
				
				currentAnimationState = STATE_WALK;
			}
		}

		//check if walk animation is playing
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
			isWalking = true;
		else if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
			isWalking = false;

	}

<<<<<<< HEAD
	// Check if player has collided with the floor
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name == "Floor")
		{
			isGrounded = true;
			animator.SetInteger("state", STATE_IDLE);
		}

	}

	void changeDirection(string direction)
	{

		if (currentDirection != direction)
		{
			if (direction == "right")
			{
				transform.Rotate(0, 180, 0);
				currentDirection = "right";
			}
			else if (direction == "left")
			{
				transform.Rotate(0, -180, 0);
				currentDirection = "left";
			}
		}

	}
    void FixedUpdate() {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (Input.GetKey("up") && isGrounded) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 250));
            //animator.SetInteger("state", STATE_JUMP);
            isGrounded = false;
        }
        else if (Input.GetKey("right"))
        {
            changeDirection("right");
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);

            if (this.currentAnimationState != STATE_WALK) {
                animator.SetInteger("state", STATE_WALK);
                currentAnimationState = STATE_WALK;
            }
        }
        else if (Input.GetKey("left"))
        {
            changeDirection("left");
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);

            if (this.currentAnimationState != STATE_IDLE)
            {
                animator.SetInteger("state", STATE_WALK);
                currentAnimationState = STATE_WALK;
            }
        }

        //check if walk animation is playing
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            isWalking = true;
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            isWalking = false;

    }

    // Check if player has collided with the floor
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Floor")
        {
            isGrounded = true;
            animator.SetInteger("state", STATE_IDLE);
        }

    }

    void changeDirection(string direction)
    {

        if (currentDirection != direction)
        {
            if (direction == "right")
            {
                transform.Rotate(0, 180, 0);
                currentDirection = "right";
            }
            else if (direction == "left")
            {
                transform.Rotate(0, -180, 0);
                currentDirection = "left";
            }
        }

    }
>>>>>>> b690323b0b5da5770e91f4ab96822feb1e384d38
}
