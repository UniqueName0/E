using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    private TestEnemy enemy;
	
	void Start(){
		enemy = transform.parent.GetComponent<TestEnemy>();
	}
	
    void OnTriggerEnter2D(Collider2D other) {
	if (other.CompareTag("Player")) enemy.DoDamage(other);
	
    }
}
