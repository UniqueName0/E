using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public int Damage;
    public bool Attacking;

    
    public abstract void Attack();
    public abstract void DoDamage(EnemyBase enemy);

    public abstract void OnTriggerEntered2D(Collider2D collider);
}
