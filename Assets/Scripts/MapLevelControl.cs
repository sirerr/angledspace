using UnityEngine;
using System.Collections;

public class MapLevelControl : MonoBehaviour {


	public GUIText mapselected;
	public GameObject map;
	private float vert;
	private float hor;
 

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		vert = Input.GetAxis("Menu2");
		hor = Input.GetAxis ("Menu1");

		if( Mathf.Abs(vert) == 1f)
		{
			map.transform.Rotate(vert*90f*(Time.deltaTime*2),0,0);
		}
		if( Mathf.Abs(vert) == -1f)
		{
			map.transform.Rotate(vert*90f*(Time.deltaTime*2),0,0);
		}

		if( Mathf.Abs(hor) == 1f)
		{
			map.transform.Rotate(0,hor*90f*(Time.deltaTime*2),0);
		}
		if( Mathf.Abs(hor) == -1f)
		{
			map.transform.Rotate(0,hor*90f*(Time.deltaTime*2),0);
		}

		RaycastHit hit;
		Ray atmap = new Ray(transform.position,Vector3.forward);

		Physics.Raycast(atmap,out hit,100f);
		mapselected.text = hit.collider.name;

	}
}
