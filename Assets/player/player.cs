using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	public float Speed = 5f;
	public float JumpForce = 5f;
	
	public int Health = 100;

	[HideInInspector]
	public bool KnockedBack = false;
	[HideInInspector]
	public Rigidbody2D rb;
	
	public ContactFilter2D GroundFilter;
	public bool Grounded => rb.IsTouching(GroundFilter);
	
	[HideInInspector]
	public bool jump;
	[HideInInspector]
	public float sideMove;
	[HideInInspector]
	public float downMove;
	[HideInInspector]
	public float FrameStall = 0;
	
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	void Update(){
		if (!KnockedBack) {
			sideMove = Input.GetAxis("Horizontal");
			downMove = Input.GetAxis("Vertical");
		}
	
		jump = Input.GetButton("Jump");
		
	}

    void FixedUpdate()
    {
        if (FrameStall > 0) {
			FrameStall--;
			return;
		}
        if (!KnockedBack) rb.velocity = new Vector2(sideMove * Speed, rb.velocity.y);
        else if (Grounded) KnockedBack = false;

        if (jump && Grounded) rb.velocity = new Vector2(rb.velocity.x, JumpForce);
    }

    public void TakeDamage() {
        //activate iframes
    }

    public void Knockback(Vector2 KnockbackForce) {
		rb.velocity = KnockbackForce;
		FrameStall = 10;
		KnockedBack = true;
	}
}
