using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public GameObject player;
	
	// Update is called once per frame
	void Update () {
		Vector3 charPos = camera.WorldToScreenPoint (player.transform.position);
		//Debug.Log(charPos);
		
		
		
		if(charPos.x < 50 || charPos.x > 450){
			transform.position = Vector3.MoveTowards (transform.position, new Vector3(player.transform.position.x, transform.position.y, transform.position.z), 0.5f);
		}
	}
}
