using UnityEngine;
using System.Collections;

public class BigmanControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();	
	}
			
	Animator anim;
	AnimatorStateInfo currentState;
	
	int idleAnim = Animator.StringToHash ("Base Layer.Idle");
	
	int raiseArm = Animator.StringToHash ("Base Layer.Raise arm");
	int keepRaised  = Animator.StringToHash ("Base Layer.keep arm raised");
	int lowerArm = Animator.StringToHash ("Base Layer.lower arm");
	
	int startCharge = Animator.StringToHash ("Base Layer.fall forward");
	int stayCharged = Animator.StringToHash ("Base Layer.stay in Ram mode");
	int endCharge = Animator.StringToHash ("Base Layer.stop ram");
	
	bool whichAtt = false;
	bool isFire = false;
	bool isCharge = false;
	bool goTime = true;
	public GameObject bigBullet;
	public GameObject bulletSpawn;

	Vector3 chargeDir;
	
	// Update is called once per frame
	void FixedUpdate () {
		currentState = anim.GetCurrentAnimatorStateInfo (0);
		//transform.LookAt (CherControl.playerPos);
		
		if(!whichAtt){
			if(currentState.nameHash == idleAnim && goTime){
				//Debug.Log ("something");
				goTime = false;
				anim.SetBool ("canShoot", true);
			}
			
			if(currentState.nameHash == keepRaised && !isFire){
				Instantiate(bigBullet, bulletSpawn.transform.position, Quaternion.LookRotation (-CherControl.playerPos));
				isFire = true;
				anim.SetBool ("lowerArm", true);
			}else if(currentState.nameHash == lowerArm){
				isFire = false;
				anim.SetBool ("canShoot", false);
				anim.SetBool ("lowerArm", false);
				StartCoroutine ("switchAtt");
			}
		}else if(whichAtt){
			if(currentState.nameHash == idleAnim && goTime){
				goTime = false;
				anim.SetBool ("canCharge", true);
				chargeDir = CherControl.playerPos - transform.position;
			}

			if(currentState.nameHash == startCharge && !isCharge){
				StartCoroutine ("doCharge");
				rigidbody.velocity = chargeDir*20;
			}else if(currentState.nameHash == endCharge){
				StartCoroutine("switchAtt");
				anim.SetBool ("canCharge", false);
				anim.SetBool ("stopCharge", false);
			}
		}
	}
	
	IEnumerator switchAtt(){
		yield return new WaitForSeconds(1);
		
		if(whichAtt){
			whichAtt = false;
		}else{
			whichAtt = true;
		}
		goTime = true;
	}

	IEnumerator doCharge(){
		yield return new WaitForSeconds(0.5f);

		isCharge = true;
		anim.SetBool("stopCharge", true);
	}
}
