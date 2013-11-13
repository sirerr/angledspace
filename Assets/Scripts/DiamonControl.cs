using UnityEngine;
using System.Collections;

public class DiamonControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("moveDiamond");
	}
	
	public int speed;
	public int lasSpeed;
	public int lasDam;
	public GameObject laser;
	bool isMove = false;
	Vector3 movePos;
	Vector3 playerPos;
	
	// Update is called once per frame
	void FixedUpdate () {
		playerPos = CherControl.playerPos;
		
		if(isMove){
			this.rigidbody.MovePosition (Vector3.MoveTowards (transform.position, movePos,  speed*Time.deltaTime));
			if(this.rigidbody.position == movePos){
				GameObject lasBlast = Instantiate (laser, transform.position, Quaternion.LookRotation (playerPos)) as GameObject;
				lasBlast.GetComponent<LaserHit>().playerPos = CherControl.playerPos;
				lasBlast.GetComponent<LaserHit>().speed = lasSpeed;
				lasBlast.GetComponent<LaserHit>().damage = lasDam;
				isMove = false;
				StartCoroutine("moveDiamond");
			}
		}
	}
	
	IEnumerator moveDiamond(){
		yield return new WaitForSeconds(1.5f);
			
		float moveX = Random.Range (5, 11);
		//float moveY = Random.Range (0, 2);
		float moveY = 0;
		float moveZ = Random.Range (5, 11);
		
		if(Random.Range (0, 2) == 0){
			moveX = playerPos.x + moveX;
		}else{
			moveX = playerPos.x - moveX;
		}
		
		if(Random.Range (0, 2) == 0){
			moveZ = playerPos.z + moveZ;
		}else{
			moveZ = playerPos.z - moveZ;
		}
		
		moveY += playerPos.y;
		
		movePos = new Vector3(moveX, moveY, moveZ);
		isMove = true;
	}
}
