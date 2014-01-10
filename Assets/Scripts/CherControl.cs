using UnityEngine;
using System.Collections;

public class CherControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3(0, grav, 0);
		
		health = maxHealth;
		power = 0;
	}
	
	public GameObject dude;
	public GameObject weapon;
	public GameObject weapTrigger;
	public GameObject spawnPoint;
	public Camera moveRef;
	public ParticleSystem sparks;
	public ParticleSystem dashes;
	
	bool ariel;
	float vertMove;
	int health;
	int power;
	public int maxHealth;
	public int maxPower;
	public static int hpHit = 0;
	public static Vector3 playerPos;
	public Texture hpBip;
	public Texture halfBip;
	bool isSpark;
	bool isJump;
	bool isDash;
	
	public int incSpeed;
	public int maxSpeed;
	public int jumpPow;
	public float grav;
	float horzSpeed;
	float vertSpeed;
	public GameObject trails;
 
	
	// Update is called once per frame
	void FixedUpdate () {
		playerPos = rigidbody.position;
		int realSpeed = incSpeed;
		
		if(isDash){
			realSpeed = incSpeed*2;
		}
		
		horzSpeed = realSpeed*Input.GetAxis ("Horizontal");
		vertSpeed = -realSpeed*Input.GetAxis ("Vertical");
		
		if(Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0){
			rigidbody.rotation = Quaternion.Lerp (rigidbody.rotation, Quaternion.LookRotation(moveRef.worldToCameraMatrix.MultiplyVector(new Vector3(horzSpeed, rigidbody.velocity.y, vertSpeed))), Time.deltaTime*10);
		}
		
		rigidbody.velocity = moveRef.worldToCameraMatrix.MultiplyVector (new Vector3(horzSpeed, rigidbody.velocity.y, vertSpeed));
		dude.transform.Rotate(new Vector3(rigidbody.velocity.z, 0, -rigidbody.velocity.x), Space.World);
		
		if(!isSpark && (vertSpeed >= incSpeed-1 || horzSpeed >= incSpeed-1)){
			sparks.Play ();
			isSpark = true;
		}else if(vertSpeed < incSpeed-2 && horzSpeed < incSpeed-2){
			sparks.Stop ();
		}

		if(Input.GetButton ("Fire1")){
			weapon.animation.Play ("Attack");
			trails.SetActive(true);


		}else if(Input.GetButton ("Fire2"))
		{ weapon.animation.Play ("Xattack");
			trails.SetActive(true);
		}else{
			trails.SetActive(false);
		}

		if(weapon.animation.isPlaying){
			weapTrigger.collider.enabled = true;
		}else{
			weapTrigger.collider.enabled = false;
		}
		
		if(Input.GetButtonDown ("Jump")){
			rigidbody.velocity = Vector3.up*jumpPow;
		}

		if(Input.GetButton ("Dash")){
			isDash = true;
			dashes.Play ();
			StartCoroutine ("dashCount");
		}
	}
		
	void OnGUI(){
		//GUI.Box (new Rect(20, 20, 200, 40), health.ToString ());
		
		for(int i=0; i<(health/20f); i++){
			if(Mathf.Abs (i-(health/20f)) <= 0.5){
				GUI.DrawTexture (new Rect(20+((int)i*35), 20, 30, 30), halfBip);
			}else{
				GUI.DrawTexture (new Rect(20+((int)i*35), 20, 30, 30), hpBip);
			}
		}
	}
	
	IEnumerator dashCount(){
		yield return new WaitForSeconds(2);
		
		isDash = false;
	}
	
	void takeHit(int dam){
		health -= dam;
		
		if(health <= 0){
			moveRef.transform.parent = transform;
			health = maxHealth;
			rigidbody.position = spawnPoint.transform.position;
			moveRef.transform.parent = null;
		}
	}
}
