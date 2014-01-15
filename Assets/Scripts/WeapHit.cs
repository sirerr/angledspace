using UnityEngine;
using System.Collections;

public class WeapHit : MonoBehaviour {

	private int enemyhit;
	private GameObject[] powerpossible;
	private int poweruplocation;
	private int pcounter;
	public GameObject circle1;
	public GameObject circle2;
	public GameObject circle3;
	public GameObject circle4;
	private int arraycount;


	// Use this for initialization
	void Start () {
		powerpossible = GameObject.FindGameObjectsWithTag("PowerP");
		Debug.Log (powerpossible.Length);
		poweruplocation = powerpossible.Length;
		pcounter = 0;
		arraycount = 0;
		 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider target){
		if(target.tag == "Enemy"){
			enemyhit++;
			Debug.Log(enemyhit);
			Debug.Log("pcounter" + pcounter);
			Debug.Log (poweruplocation);
		if(pcounter < poweruplocation)
				{
				switch(enemyhit)

				{
				case 5:
					Instantiate (circle1,powerpossible[pcounter].transform.position,Quaternion.identity);
					Debug.Log ("instantiate");
				break;
				case 10:
				Instantiate (circle2,powerpossible[pcounter].transform.position,Quaternion.identity);
				break;
				case 15:
				Instantiate (circle3,powerpossible[pcounter].transform.position,Quaternion.identity);
				break;
				case 20:
				Instantiate (circle4,powerpossible[pcounter].transform.position,Quaternion.identity);
					pcounter++;
					enemyhit = 0;
					break;
				default:
					break;
				}

			} 
			target.gameObject.SendMessage ("takeHit");
		}
	}
}
