using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
	public int Health;
	public int Damage;
	public int Speed;
	
    public abstract void TakeDamage();
    public abstract void DoDamage(Collider2D TargetPlayer);
    public abstract void Knockback(int KnockbackForce);
}
