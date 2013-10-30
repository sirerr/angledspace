using UnityEngine;
using System.Collections;

public class CubexHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	bool punch;
	bool isPick;
	Vector3 playerLoc;
	
	// Update is called once per frame
	void FixedUpdate () {
		CubexControl control = transform.parent.GetComponent<CubexControl>();
		if(isPick == true){
		if(punch == true){
			//rigidbody.MovePosition(Vector3.MoveTowards (rigidbody.position, control.playerLoc, control.speed*Time.deltaTime));
		}else{
		//	rigidbody.MovePosition(Vector3.MoveTowards (rigidbody.position, transform.parent.position, control.speed*Time.deltaTime));
			
			if(rigidbody.position == transform.parent.position){
					isPick = false;
				//StartCoroutine ("waitAttack");
				//rigidbody.MovePosition (Vector3.MoveTowards (transform.position, player.transform.position, speed*Time.deltaTime));
			}
			}
		}	
	}
	
	void takeTurn(){
		//playerLoc = transform.parent.GetComponent<CubexControl>().player.transform.position;
		isPick = true;
		punch = true;
	}
	
	void OnTriggerEnter(Collider target){
	//CubexControl control = transform.parent.GetComponent<CubexControl>();
		if(target.tag == "Player"){
			target.SendMessage ("takeHit");
			punch = false;
			Debug.Log (target.tag);
		}
	}
}
