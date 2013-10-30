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
		Vector3 charOff = camera.worldToCameraMatrix.MultiplyVector(player.rigidbody.position);
		Debug.Log(charVel.z);
		
		if((charPos.x < Screen.width*0.2 && charVel.x < 0) || (charPos.x > Screen.width*0.8 && charVel.x > 0)){
			transform.position += transform.right*charVel.x*Time.deltaTime;
		}
		
		/*if((charOff.z < Screen.height*0.2 && charVel.z > 0) || (charPos.z > Screen.height*0.5 && charVel.z < 0)){
			transform.position += transform.forward*-charVel.z*Time.deltaTime;
		}*/
	}
}
