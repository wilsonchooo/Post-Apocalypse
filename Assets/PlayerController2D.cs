using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour {

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriterenderer;

    bool isGrounded;

    [SerializeField]
    Transform groundCheck; 
    

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(2, rb2d.velocity.y);
            animator.Play("run_animation");
            spriterenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-2, rb2d.velocity.y);
            animator.Play("run_animation");
            spriterenderer.flipX = true;
        }
        else
        {
            animator.Play("idle_animation");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 2);
            animator.Play("jump_animation");
        }

    }
}
