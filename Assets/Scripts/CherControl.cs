using UnityEngine;
using System.Collections;

public class CherControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3(0, grav, 0);
	}
	
	public GameObject dude;
	public GameObject weapon;
	public GameObject weapTrigger;
	bool ariel;
	float vertMove;
	
	public int incSpeed;
	public int maxSpeed;
	public int jumpPow;
	public float grav;
	float horzSpeed;
	float vertSpeed;
	
	// Update is called once per frame
	void FixedUpdate () {		
		/*if(Input.GetButton("Horizontal") && Mathf.Abs (rigidbody.velocity.x) < maxSpeed){
			horzSpeed += incSpeed*Input.GetAxis("Horizontal");
		}else if(Mathf.Abs (horzSpeed) > 0 && Mathf.Abs (horzSpeed) < 1){
			horzSpeed = 0;
		}else if(horzSpeed < 0){
			horzSpeed += incSpeed;
		}else if(horzSpeed > 0){
			horzSpeed -= incSpeed;
		}
		
		if(Input.GetButton ("Vertical") && Mathf.Abs (rigidbody.velocity.z) < maxSpeed){
			vertSpeed += incSpeed*Input.GetAxis ("Vertical");
		}else if(Mathf.Abs (vertSpeed) > 0 && Mathf.Abs (vertSpeed) < 1){
			vertSpeed = 0;
		}else if(vertSpeed < 0){
			vertSpeed += incSpeed;
		}else if(vertSpeed > 0){
			vertSpeed -= incSpeed;
		}*/
		
		horzSpeed = incSpeed*Input.GetAxis ("Horizontal");
		vertSpeed = incSpeed*Input.GetAxis ("Vertical");
		
		//transform.LookAt (+this.transform.position);
		rigidbody.velocity = new Vector3(horzSpeed, rigidbody.velocity.y, vertSpeed);
		dude.transform.Rotate(new Vector3(rigidbody.velocity.z, 0, -rigidbody.velocity.x), Space.World);
		
		if(Input.GetButton ("Attack")){
			weapon.animation.Play ("Attack");
		}
		
		if(weapon.animation.isPlaying){
			weapTrigger.collider.enabled = true;
		}else{
			weapTrigger.collider.enabled = false;
		}
		
		if(Input.GetButtonDown ("Jump")){
			rigidbody.velocity = Vector3.up*jumpPow;
		}
	}
		
	void OnGUI(){
		GUI.Box (new Rect(20, 20, 100, 100), rigidbody.velocity.ToString ());
	}
}
