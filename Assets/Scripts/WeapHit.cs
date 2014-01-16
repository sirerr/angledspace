using UnityEngine;
using System.Collections;

public class WeapHit : MonoBehaviour {

	private int enemyhit;
	private GameObject[] powerpossible;
	private int[] powerlevel;
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
		arraycount = 0;
		powerlevel = new int[powerpossible.Length];
		Debug.Log (powerlevel.Length);
		poweruplocation = powerpossible.Length;
		pcounter = 0;

		 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider target){
		if(target.tag == "Enemy"){
			enemyhit++;


			Debug.Log(enemyhit);
		//	Debug.Log("pcounter" + pcounter);
		//	Debug.Log (poweruplocation);
		if(pcounter < poweruplocation)
				{
				powerlevel[pcounter] = enemyhit;

				switch(enemyhit)

				{
				case 5:
				Instantiate (circle1,powerpossible[pcounter].transform.position,Quaternion.identity);
					powerlevel[pcounter] = 5;
	 
				break;
				case 10:
				Instantiate (circle2,powerpossible[pcounter].transform.position,Quaternion.identity);
					powerlevel[pcounter] = 10;
				Debug.Log("powerlevel "+ pcounter);
			//		Debug.Log(enemyhit);
				break;
				case 15:
				Instantiate (circle3,powerpossible[pcounter].transform.position,Quaternion.identity);
					powerlevel[pcounter] = 15;
				break;
				case 20:
				Instantiate (circle4,powerpossible[pcounter].transform.position,Quaternion.identity);

					powerlevel[pcounter] = 20;
				//	Debug.Log(powerlevel[pcounter]);
					pcounter++;
					enemyhit = 0;
					break;
				}
			} 
			target.gameObject.SendMessage ("takeHit");
		}
	}
}
