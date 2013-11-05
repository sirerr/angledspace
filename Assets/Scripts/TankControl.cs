using UnityEngine;
using System.Collections;

public class TankControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("tankMove");
	}
	
	public GameObject bullet;
	public GameObject tankTop;
	public GameObject topBullet;
	public GameObject bulletSpawn;
	public GameObject topSpawn;

	bool inRange = false;
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!inRange && Vector3.Distance(transform.position, CherControl.playerPos) < 10){
			inRange = true;
			animation.Stop ("TankMove");
			StartCoroutine ("topShot");
		}else if(inRange){
			Debug.Log ("print");
			tankTop.transform.LookAt (CherControl.playerPos);
		}
	}
	
	IEnumerator tankMove(){
		yield return new WaitForSeconds(5f);
		
		while(!inRange){
			Instantiate(bullet, bulletSpawn.transform.position, transform.rotation);
			yield return new WaitForSeconds(5f);
		}
	}
	
	IEnumerator topShot(){
		while(inRange){
			yield return new WaitForSeconds(1f);
		
			for(int i=0; i<3; i++){
				Instantiate (topBullet, topSpawn.transform.position, tankTop.transform.rotation);
				yield return new WaitForSeconds(0.25f);
			}
		}
	}
}
