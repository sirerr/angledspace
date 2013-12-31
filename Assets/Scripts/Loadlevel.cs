using UnityEngine;
using System.Collections;

public class Loadlevel : MonoBehaviour {
	public int level;
	public GUIText levelselected;
	private float apress;
	private string looker;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		apress = Input.GetAxis("Dash");

		RaycastHit hit;
		Ray starter = new Ray(transform.position,Vector3.down);

		if(Physics.Raycast(starter,out hit,100f)){
		looker = hit.collider.gameObject.name;
		Debug.Log (looker);

		if(looker == "looker")
		{
			//Debug.Log ("Hitting looker");
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
}
