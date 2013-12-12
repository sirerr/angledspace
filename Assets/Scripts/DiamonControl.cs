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

	int shotNum = 0;
	
	// Update is called once per frame
	void FixedUpdate () {
		playerPos = CherControl.playerPos;
		rigidbody.MovePosition (Vector3.MoveTowards (transform.position, movePos,  speed*Time.deltaTime));
		
		if(isMove){
			if(this.rigidbody.position == movePos){
				GameObject lasBlast = Instantiate (laser, transform.position, Quaternion.LookRotation (playerPos)) as GameObject;
				lasBlast.GetComponent<LaserHit>().playerPos = CherControl.playerPos;
				lasBlast.GetComponent<LaserHit>().speed = lasSpeed;
				lasBlast.GetComponent<LaserHit>().damage = lasDam;
				isMove = false;
				shotNum++;
				if(shotNum >= 3){
					StartCoroutine ("powerDown");
				}else{
					StartCoroutine("moveDiamond");
				}
			}
		}
	}

	void onCollisionEnter(Collision target){
		if(target.gameObject.tag == "Level"){
			movePos = transform.position;
		}
	}
	
	IEnumerator moveDiamond(){
		yield return new WaitForSeconds(1.5f);

		RaycastHit hit;
		float diaHeight = 0;
		if(Physics.Raycast (transform.position, -transform.up, out hit)){
			diaHeight = hit.distance;
		}
			
		float moveX = Random.Range (5, 10);
		float moveY = Random.Range (1, 10);
		float moveZ = Random.Range (5, 10);

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
		
		moveY += (transform.position.y - diaHeight);
		
		movePos = new Vector3(moveX, moveY, moveZ);
		isMove = true;
	}

	IEnumerator powerDown(){
		RaycastHit hit;
		float diaHeight = 0;
		if(Physics.Raycast (transform.position, -transform.up, out hit)){
			diaHeight = hit.distance;
		}

		speed /= 2;

		movePos = new Vector3(transform.position.x, transform.position.y-diaHeight, transform.position.z);

		yield return new WaitForSeconds(3);

		speed *= 2;
		shotNum = 0;
		StartCoroutine ("moveDiamond");
	}
}
