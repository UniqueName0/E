using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveThroughUnder : MonoBehaviour
{
	[HideInInspector]
	public BoxCollider2D Platform; 
	
	void Start()
    {
        Platform = transform.parent.GetComponent<BoxCollider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
		Physics2D.IgnoreCollision(other, Platform, true);
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        Physics2D.IgnoreCollision(other, Platform, false);
    }
    
}
