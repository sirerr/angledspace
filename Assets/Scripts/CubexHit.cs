using UnityEngine;
using System.Collections;

public class CubexHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnTriggerEnter(Collider target){
	CubexControl control = transform.parent.GetComponent<CubexControl>();
		if(target.tag == "Player"){
			target.SendMessage ("takeHit");
			control.punch = false;
			Debug.Log (target.tag);
		}
	}
}
