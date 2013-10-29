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
		//Debug.Log(charPos);
		
		if(charPos.x < Screen.width*0.1 || charPos.x > Screen.width*0.9){
			transform.position += Camera.main.worldToCameraMatrix.MultiplyVector( Vector3.right*player.rigidbody.velocity.x*Time.deltaTime);
		}
	}
}
