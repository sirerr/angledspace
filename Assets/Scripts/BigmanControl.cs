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
	
	bool isCharge = false;
	bool isFire = false;
	public GameObject bigBullet;
	public GameObject bulletSpawn;
	
	// Update is called once per frame
	void FixedUpdate () {
		currentState = anim.GetCurrentAnimatorStateInfo (0);
		
		if(!isCharge){
			if(currentState.nameHash == idleAnim && Vector3.Distance (transform.position, CherControl.playerPos) < 100){
				anim.SetBool ("canShoot", true);
			}
			
			if(currentState.nameHash == keepRaised && !isFire){
				Instantiate(bigBullet, bulletSpawn.transform.position, Quaternion.LookRotation (-CherControl.playerPos));
				isFire = true;
				anim.SetBool ("lowerArm", true);
			}else if(currentState.nameHash == lowerArm){
				isFire = false;
			}
		}else if(isCharge){
			if(currentState.nameHash == idleAnim){
			}
		}
	}
	
	IEnumerator switchAtt(){
		yield return new WaitForSeconds(1);
		
		if(isCharge){
			isCharge = false;
		}else{
			isCharge = true;
		}
	}
}
