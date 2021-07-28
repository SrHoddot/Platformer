using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour 
{
	Rigidbody2D rb;

	public float jumpForce = 20;

	public float moveSpeed = 5f;

	public bool isGrounded;
	public bool isJumping;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}


	void Update()
	{
		Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
		transform.position += movement * Time.deltaTime * moveSpeed;


		if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			isJumping = true;
		}
		else if (Input.GetKeyDown(KeyCode.W) && isJumping == true)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			isJumping = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		isGrounded = false;
	}
}
