using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public GameObject player;
	Vector3 resetPos;
	bool offScreen = false;
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 charPos = camera.WorldToScreenPoint (CherControl.playerPos);
		Vector3 charVel = camera.worldToCameraMatrix.MultiplyVector(player.rigidbody.velocity);
		
		if(charPos.x < 0 || charPos.x > Screen.width || charPos.y < 0 || charPos.y > Screen.height ||
			Vector3.Distance (transform.position, player.transform.position) < 0 || Vector3.Distance (transform.position, player.transform.position) > 100){
			//resetPos = camera.WorldToScreenPoint (CherControl.playerPos);
			//resetPos.z -= 50;
			resetPos = CherControl.playerPos;
			resetPos.x += 50;
		
			//offScreen = true;
		}
			
		if((charPos.x < Screen.width*0.4f && charVel.x < 0) || (charPos.x > Screen.width*0.6f && charVel.x > 0)){
			transform.position += transform.right*charVel.x*Time.deltaTime;
		}

		if((charPos.y < Screen.height*0.4f && charVel.y < 0) || (charPos.y > Screen.height*0.6f && charVel.y > 0)){
			transform.position += transform.up*charVel.y*Time.deltaTime;
		}
			
		if((Vector3.Distance (transform.position, player.transform.position) > 50 && charVel.z < 0) || (Vector3.Distance (transform.position, player.transform.position) < 25 && charVel.z > 0)){
			transform.position += transform.forward*-charVel.z*Time.deltaTime;
		}
	}

	void OnGUI(){
		Vector3 charVel = camera.worldToCameraMatrix.MultiplyVector(player.rigidbody.velocity);

		GUI.Box (new Rect(30, 60, 150, 50), charVel.ToString ());
	}
}