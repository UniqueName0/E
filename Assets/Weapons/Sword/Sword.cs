using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : WeaponBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack() {}
    public override void DoDamage(EnemyBase enemy) {}

    public override void OnTriggerEntered2D(Collider2D collider) {}
}
