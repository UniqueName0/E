using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCheck : MonoBehaviour
{
	private TestEnemy enemy;
	
	void Start(){
		enemy = (TestEnemy)transform.parent.GetComponent(typeof(TestEnemy));
	}
	
    void OnTriggerExit2D() {
		enemy.Speed *= -1;
	}
}
