using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public int speed;
	public int damage;
	
	// Update is called once per frame
	void Update () {
		rigidbody.MovePosition (transform.position + transform.right*speed*Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider target){
		if(target.tag == "Player"){
			target.SendMessage ("takeHit", damage);
		}

		Destroy(gameObject);
	}
}
