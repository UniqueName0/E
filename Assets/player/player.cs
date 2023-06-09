using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	public float Speed = 5f;
	public float JumpForce = 5f;
	public float DashForce = 20f;


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
	[HideInInspector]
	public float IFrames = 0;


	[HideInInspector]
	public List<CoreBase> Cores = new List<CoreBase>();

	void Start()
    {
        rb = GetComponent<Rigidbody2D>();

		Cores.ForEach(i => i.StartAction(this));
	}

	void Update(){
		if (IFrames > 0) IFrames--;
		
		if (DisableInput) {
			return;
		}

		sideMove = Input.GetAxis("Horizontal");
		downMove = Input.GetAxis("Vertical");
		
		if (Input.GetButton("Dash") && DashTime <= 0){
			AddedDashForce = DashForce;
			AddedDashForce *= Mathf.Sign(sideMove);
			DashTime = 1.2f;
		}
	
		if (DashTime > 0f) DashTime -= Time.deltaTime;
		if (DashTime < 1f) {
			AddedDashForce = 1f;
			DisableInput = false;
		} else sideMove = 1f;
		
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

		if (jump && Grounded) { 
			rb.velocity = new Vector2(rb.velocity.x, JumpForce); 
			Cores.ForEach(i => i.JumpAction(this));
		}
    }

	public void TakeDamage()
	{
		this.IFrames = 20;
		Cores.ForEach(i => i.TakeDamageAction(this));
	}

    public void Knockback(Vector2 KnockbackForce) {
		rb.velocity = KnockbackForce;
		FrameStall = 10;
		DashTime = 0f;
		DisableInput = true;
	}
}
