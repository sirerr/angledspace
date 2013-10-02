using UnityEngine;
using System.Collections;

public class EnemControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public int health;
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider target){
		if(target.tag == "PWeapon"){
			health--;
			
			if(health <= 0){
				Destroy (this.gameObject);
			}
		}
	}
}
