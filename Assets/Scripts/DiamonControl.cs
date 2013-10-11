using UnityEngine;
using System.Collections;

public class DiamonControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("moveDiamond");
	}
	
	public GameObject player;
	public int speed;
	bool isMove = false;
	Vector3 movePos;
	
	// Update is called once per frame
	void FixedUpdate () {
		if(isMove){
			this.rigidbody.MovePosition (Vector3.MoveTowards (transform.position, movePos,  speed*Time.deltaTime));
			if(this.rigidbody.position == movePos){
				isMove = false;
				StartCoroutine("moveDiamond");
			}
		}
	}
	
	IEnumerator moveDiamond(){
		yield return new WaitForSeconds(1.5f);
			
		float moveX = Random.Range (5, 11);
		float moveY = Random.Range (3, 9);
		float moveZ = Random.Range (5, 11);
		
		if(Random.Range (0, 2) == 0){
			moveX = player.transform.position.x + moveX;
		}else{
			moveX = player.transform.position.x - moveX;
		}
		
		if(Random.Range (0, 2) == 0){
			moveZ = player.transform.position.z + moveZ;
		}else{
			moveZ = player.transform.position.z - moveZ;
		}
		
		movePos = new Vector3(moveX, moveY, moveZ);
		Debug.Log (movePos);
		isMove = true;
	}
}
