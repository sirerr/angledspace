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
	Vector3 playerLoc;
	Vector3 handLoc;
	bool punch;
	float speed = 20;
	
	public GameObject player;
	
	// Update is called once per frame
	void FixedUpdate () {
		//playerLoc = player.transform.position;
		
		if(punch == true){
			pickHand.rigidbody.MovePosition(Vector3.MoveTowards (pickHand.rigidbody.position, playerLoc, speed));
		}else{
			pickHand.rigidbody.MovePosition(Vector3.MoveTowards (pickHand.rigidbody.position, handLoc, speed));
			
			if(pickHand.rigidbody.position == handLoc){
				//StartCoroutine ("waitAttack");
			}
		}
		
		if(pickHand.rigidbody.position == playerLoc){
			punch = false;
		}
	}
	
	/*IEnumerator waitAttack(){
		yield return new WaitForSeconds(2);
		
		doAttack ();
	}
	
	void doAttack(){
		int hand = Random.Range (0, 2);
		print (punch);
		if(hand == 0){
			pickHand = leftHand;
		}else if(hand == 1){
			pickHand = rightHand;
		}
		
		playerLoc = player.transform.position;
		handLoc = pickHand.transform.position;
		punch = true;
		
		StartCoroutine ("handOut");
	}
	
	IEnumerator handOut(){
		yield return new WaitForSeconds(1);
		
		punch = false;
	}*/
	
	IEnumerator doAttack(){
		while(true){
			yield return new WaitForSeconds(2);
		int hand = Random.Range (0, 2);
		
		if(hand == 0){
			pickHand = leftHand;
		}else if(hand == 1){
			pickHand = rightHand;
		}
		
		playerLoc = player.transform.position;
		handLoc = pickHand.transform.position;
		punch = true;
			
			yield return new WaitForSeconds(1);
			punch = false;
		
		//StartCoroutine ("handOut");
		}
	}
	
	void OnCollisionEnter(Collision target){
		if(target.rigidbody.tag == "Player"){
			target.rigidbody.SendMessage ("takeHit");
			punch = false;
			Debug.Log (target.rigidbody.tag);
		}
	}
}
