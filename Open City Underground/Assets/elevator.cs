using UnityEngine;
using System.Collections;

public class elevator : MonoBehaviour
{
	public GameObject[] hoverHeights = {};
	Vector3 targetPos;
	private int currentIndex = 1;
	private bool isUp; // 
	public float speed = 5f;
	private bool elevatorMove = false;
	public GameObject Mover;
	float targetDistance;
	// Use this for initialization
	void Start ()
	{
			
		targetPos = Mover.transform.position;
		targetPos.y = hoverHeights [currentIndex].transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		
		 
		if (elevatorMove) {
			 targetDistance = Vector3.Distance (Mover.transform.position, targetPos); 
			if (targetDistance <= 0.1F) { 
				elevatorMove = false;
			
			
				Debug.Log ("size:" + currentIndex + hoverHeights.Length);
				if (currentIndex == hoverHeights.Length-1) {
					
					currentIndex = 0;
				} else {
					currentIndex++;
				}
				Debug.Log (" aftersize:" + currentIndex + hoverHeights.Length);
				targetPos = Mover.transform.position;
				targetPos.y = hoverHeights[currentIndex].transform.position.y;
			} else {
				Vector3 targetDirection = targetPos - Mover.transform.position;
				targetDirection.Normalize ();
				Vector3 transdirection = targetDirection * Time.deltaTime * speed;



				Mover.transform.Translate (transdirection);
			
				
			}
		}
		
	}
	
	void OnTriggerEnter (Collider collider)
	{
		Debug.Log ("hit" + collider.transform.name);
		if (collider.transform.tag == "Player") { 
			elevatorMove = true;
		}
		if (collider.transform.name == "FirstPersonController") { 
			Debug.Log ("Game Over");
				
		} 
	}
		
	void OnTriggerExit (Collider collider)
	{
		Debug.Log ("hit" + collider.transform.name);
		//elevatorMove = false;
		
	}
	
	public void OnDrawGizmos ()
	{
		Gizmos.color = Color.red;
      
               
		Gizmos.DrawLine (transform.position, targetPos);
         
	}
}

