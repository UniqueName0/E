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
    
    public override void DoDamage(Collider2D playerCollider) {
	player TargetPlayer = playerCollider.GetComponent<player>();        
	TargetPlayer.Health -= this.Damage;
        TargetPlayer.TakeDamage();
	int KnockbackForce = 5;
	if (playerCollider.transform.position.x < transform.position.x) KnockbackForce *= -1;
	TargetPlayer.Knockback(new Vector2(KnockbackForce, 5));
    }
    
    public override void TakeDamage() {}
    
    public override void Knockback(int KnockbackForce) {
        
    }
}
