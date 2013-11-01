using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public GameObject player;
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 charPos = camera.WorldToScreenPoint (player.transform.position);
		Vector3 charVel = camera.worldToCameraMatrix.MultiplyVector(player.rigidbody.velocity);
		
		if((charPos.x < Screen.width*0.4 && charVel.x < 0) || (charPos.x > Screen.width*0.6 && charVel.x > 0)){
			transform.position += transform.right*charVel.x*Time.deltaTime;
		}
		
		if((Vector3.Distance (transform.position, player.transform.position) > 50 && charVel.z < 0) || (Vector3.Distance (transform.position, player.transform.position) < 25 && charVel.z > 0)){
			transform.position += transform.forward*-charVel.z*Time.deltaTime;
		}
	}
}
