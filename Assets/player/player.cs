using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	public float Speed = 5f;
	public float JumpForce = 5f;
	public float DashForce = 2f;


	[HideInInspector]
	public float DashTime = 0f;
	
	public int Health = 100;

	[HideInInspector]
	public bool DisableInput = false;
	[HideInInspector]
	public Rigidbody2D rb;
	
	public ContactFilter2D GroundFilter;
	public bool Grounded => rb.IsTouching(GroundFilter);
	
	[HideInInspector]
	public bool jump;
	[HideInInspector]
	public bool dash;
	[HideInInspector]
	public float AddedDashForce = 1f;
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
		
		if (DisableInput) {
			return;
		}

		sideMove = Input.GetAxis("Horizontal");
		downMove = Input.GetAxis("Vertical");
		
		if (Input.GetButton("Dash") && DashTime <= 0){
			AddedDashForce = DashForce;
			DashTime = 1.2f;
		}
	
		if (DashTime > 0f) DashTime -= Time.deltaTime;
		if (DashTime < 1f) {
			AddedDashForce = 1f;
			DisableInput = false;
		} else sideMove = Mathf.Sin(sideMove);
		
		jump = Input.GetButton("Jump");
		
	}

    void FixedUpdate()
    {
        if (FrameStall > 0) {
			FrameStall--;
			return;
		}
        if (!DisableInput) {
			rb.velocity = new Vector2(sideMove * Speed * AddedDashForce, rb.velocity.y);
		}
        else if (Grounded) DisableInput = false;

        if (jump && Grounded) rb.velocity = new Vector2(rb.velocity.x, JumpForce);
    }

    public void TakeDamage() {
        //activate iframes
    }

    public void Knockback(Vector2 KnockbackForce) {
		rb.velocity = KnockbackForce;
		FrameStall = 10;
		DashTime = 0f;
		DisableInput = true;
	}
}
