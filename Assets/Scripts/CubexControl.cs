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
			pickHand.rigidbody.MovePosition(Vector3.MoveTowards (pickHand.rigidbody.position, playerLoc, speed*Time.deltaTime));
		}else{
			pickHand.rigidbody.MovePosition(Vector3.MoveTowards (pickHand.rigidbody.position, handLoc, speed*Time.deltaTime));
		}
		
		if(pickHand.rigidbody.position == playerLoc){
			punch = false;
		}
	}
	
	IEnumerator doAttack(){
		while(true){
			yield return new WaitForSeconds(1);
			
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
			
			yield return new WaitForSeconds(1);
			
			punch = false;
		}
	}
}
