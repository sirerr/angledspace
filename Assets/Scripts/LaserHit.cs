using UnityEngine;
using System.Collections;

public class LaserHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	public int speed;
	public int damage;
	public Vector3 playerPos;
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody.MovePosition (Vector3.MoveTowards(transform.position, playerPos, speed*Time.deltaTime));
		
		if(transform.position == playerPos){
			Destroy (gameObject);
		}
	}
	
	void OnTriggerEnter(Collider target){
		if(target.tag == "Player"){
			target.SendMessage ("takeHit", damage);
		}
		
		Destroy (gameObject);
	}
}
