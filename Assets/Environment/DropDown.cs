using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    [HideInInspector]
	public BoxCollider2D Platform;
	[HideInInspector]
	public Collider2D playerInside;
	
	void Start()
    {
        Platform = transform.parent.GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
		if (playerInside && Input.GetAxis("Vertical") < 0) Physics2D.IgnoreCollision(playerInside, Platform, true);
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag("Player")) playerInside = other;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
		if (other.CompareTag("Player")) playerInside = null;
	}
}
