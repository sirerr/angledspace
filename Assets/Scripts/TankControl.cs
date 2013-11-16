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
	public int bulletDam;
	public int bulletSpeed;
	public int topDam;
	public int topSpeed;

	bool inRange = false;
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!inRange && Vector3.Distance(transform.position, CherControl.playerPos) < 10){
			inRange = true;
			animation.Stop ("TankMove");
			StartCoroutine ("topShot");
		}else if(inRange){
			tankTop.transform.LookAt (CherControl.playerPos);
		}
	}
	
	IEnumerator tankMove(){
		yield return new WaitForSeconds(5f);
		
		while(!inRange){
			GameObject newBull = Instantiate(bullet, bulletSpawn.transform.position, transform.rotation) as GameObject;
			newBull.GetComponent<BulletControl>().speed = 20;
			newBull.GetComponent<BulletControl>().damage = 10;
			
			yield return new WaitForSeconds(5f);
		}
	}
	
	IEnumerator topShot(){
		while(inRange){
			yield return new WaitForSeconds(1f);
		
			for(int i=0; i<3; i++){
				GameObject newBull = Instantiate (topBullet, topSpawn.transform.position, topSpawn.transform.rotation) as GameObject;
				
				newBull.GetComponent<BulletControl>().speed = 30;
				newBull.GetComponent<BulletControl>().damage = 5;
				yield return new WaitForSeconds(0.25f);
			}
		}
	}
}
