using UnityEngine;
using System.Collections;

public class PartDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("playDeath");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator playDeath(){
		yield return new WaitForSeconds(particleSystem.duration);
		Destroy (gameObject);
	}
}
