using UnityEngine;
using System.Collections;

public class LaserHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//playerPos = GetComponent<CameraControl>().player.transform.position;//GetComponent<DiamonControl>().player.transform.position;		
	}
	
	public int speed;
	public GameObject player;
	public Vector3 playerPos;
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody.MovePosition (Vector3.MoveTowards(transform.position, playerPos, speed*Time.deltaTime));
		
		if(transform.position == playerPos){
			Destroy (gameObject);
		}
	}
	
	void OnTriggerEnter(Collider target){
		Debug.Log ("hit stuff");
		if(target.tag == "Player"){
			target.SendMessage ("takeHit");
		}
		
		Destroy (gameObject);
	}
}
