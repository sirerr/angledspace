using UnityEngine;
using System.Collections;

public class TankControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("tankMove");
	}
	
	public GameObject bullet;
	public GameObject bulletSpawn;
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator tankMove(){
		while(true){
			yield return new WaitForSeconds(5f);
			
			Instantiate(bullet, bulletSpawn.transform.position, transform.rotation);
		}
	}
}
