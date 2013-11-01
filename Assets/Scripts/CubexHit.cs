using UnityEngine;
using System.Collections;

public class CubexHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		baseLoc = transform.position;
	}

	bool punch = false;
	bool isDone = true;
	Vector3 playerLoc;
	Vector3 baseLoc;
	public int speed = 20;
	
	// Update is called once per frame
	void FixedUpdate () {
		if(punch){
			rigidbody.MovePosition (Vector3.MoveTowards (rigidbody.position, playerLoc, speed*Time.deltaTime));
				if(rigidbody.position == playerLoc){
					punch = false;
				}
		}else if(rigidbody.position != transform.parent.position){
			rigidbody.MovePosition(Vector3.MoveTowards (rigidbody.position, transform.parent.position, speed*Time.deltaTime));
		}else if(!isDone){
			SendMessageUpwards("endPunch");
			isDone = true;
		}
	}
	
	IEnumerator punchTime(){
		yield return new WaitForSeconds(1f);
		punch = false;
	}
	
	void takeTurn(){
		playerLoc = CherControl.playerPos;
		baseLoc = transform.position;
		punch = true;
		isDone = false;
		
		StartCoroutine ("punchTime");
	}
	
	void OnTriggerEnter(Collider target){
		if(target.tag == "Player" && punch){
			target.SendMessage ("takeHit");
			punch = false;
		}
	}
}
