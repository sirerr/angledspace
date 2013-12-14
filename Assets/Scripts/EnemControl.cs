using UnityEngine;
using System.Collections;

public class EnemControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public int health;
	public GameObject charBody;
	public ParticleSystem onDeath;
	public ParticleSystem onHit;
	
	// Update is called once per frame
	void Update () {
	}
	
	void takeHit(){
		health--;
		Instantiate (onHit, transform.position, Quaternion.identity);
		if(health <= 0){
			Instantiate (onDeath, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
