using UnityEngine;
using System.Collections;

public class BigmanFace : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//transform.LookAt (CherControl.playerPos);
		rigidbody.rotation = Quaternion.LookRotation (new Vector3(CherControl.playerPos.x, 0, CherControl.playerPos.z));
	}
}
