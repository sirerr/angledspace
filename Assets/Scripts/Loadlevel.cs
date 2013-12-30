using UnityEngine;
using System.Collections;

public class Loadlevel : MonoBehaviour {
	public int level;
	public GUIText levelselected;
	public GameObject lookater;
	private float apress;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		apress = Input.GetAxis("Dash");

		RaycastHit hit;
		Ray starter = new Ray(transform.position,Vector3.up);

		Physics.Raycast(starter,out hit,100f);
	
		if(hit.collider.gameObject == lookater)
		{
		
			levelselected.text = "Press A to Start";

			if(apress == 1){
			Application.LoadLevel(level);
			}
		}
		else{
			levelselected.text = "...";
		}

	}
}
