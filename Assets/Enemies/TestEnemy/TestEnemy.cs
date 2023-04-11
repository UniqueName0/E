using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : EnemyBase
{		
	[HideInInspector]
	public Rigidbody2D rb;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Speed, rb.velocity.y);
    }
    
    public override void DoDamage(player TargetPlayer) {}
    
    public override void TakeDamage() {}
    
    public override void Knockback(int KnockbackAmount) {}
}
