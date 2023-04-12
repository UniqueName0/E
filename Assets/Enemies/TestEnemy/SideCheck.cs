using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCheck : MonoBehaviour
{
	private TestEnemy enemy;
	
	void Start(){
		enemy = transform.parent.GetComponent<TestEnemy>();
	}
	
    void OnTriggerExit2D() {
		enemy.Speed *= -1;
	}
}
