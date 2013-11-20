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
		Vector3 charPos = new Vector3(CherControl.playerPos.x, transform.position.y, CherControl.playerPos.z);
		Vector3 enemPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		if(isMoving){
			//rigidbody.rotation = Quaternion.LookRotation (new Vector3(CherControl.playerPos.x, 0, CherControl.playerPos.z));
			transform.LookAt (charPos);
			if(Vector3.Distance (rigidbody.position, CherControl.playerPos) > 15){
				rigidbody.velocity = (charPos-enemPos)*Time.deltaTime*5;
			}else if(Vector3.Distance (transform.position, CherControl.playerPos) < 7){
				rigidbody.velocity = (enemPos - charPos)*Time.deltaTime*5;
			}
		}
	}
	
	void endPunch(){
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
