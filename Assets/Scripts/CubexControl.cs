using UnityEngine;
using System.Collections;

public class CubexControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("doAttack");
	}
	
	public GameObject leftHand;
	public GameObject rightHand;
	GameObject pickHand;
	Vector3 handLoc;
	bool isMoving = true;
	public int speed = 3;
	public int hitSpeed;
	public int damage;
	
	// Update is called once per frame
	void FixedUpdate () {
		if(isMoving){
		 	transform.LookAt (CherControl.playerPos);
			if(Vector3.Distance (rigidbody.position, CherControl.playerPos) > 15){
				rigidbody.velocity = transform.forward*5;
			}else if(Vector3.Distance (transform.position, CherControl.playerPos) < 7){
				rigidbody.velocity = -transform.forward*5;
			}
		}
	}
	
	void endPunch(){
		Debug.Log ("reset");
		rigidbody.isKinematic = false;
		leftHand.animation.Play ("IdleHand");
		rightHand.animation.Play ("IdleHand");
		
		isMoving = true;
		
		StartCoroutine ("doAttack");
	}
	
	IEnumerator doAttack(){
		yield return new WaitForSeconds(2);
		isMoving = false;
		rigidbody.isKinematic = true;
		
		leftHand.animation.Stop ("IdleHand");
		rightHand.animation.Stop ("IdleHand");
		
		int hand = Random.Range (0, 2);
		if(hand == 0){
			leftHand.SendMessage ("takeTurn");
		}else if(hand == 1){
			rightHand.SendMessage("takeTurn");
		}
	}
}
