using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	public float Speed = 5f;
	public float JumpForce = 5f;
	
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
	
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	void Update(){
		sideMove = Input.GetAxis("Horizontal");
		downMove = Input.GetAxis("Vertical");
		
		jump = Input.GetButton("Jump");
		
	}
    void FixedUpdate()
    {
        
        rb.velocity = new Vector2(sideMove * Speed, rb.velocity.y);
        
        if (jump && Grounded) {
			rb.velocity = new Vector2(rb.velocity.x, 0);
			rb.velocity += Vector2.up * JumpForce;
		}
    }
}
