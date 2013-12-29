using UnityEngine;
using System.Collections;

public class HordeLevelControl : MonoBehaviour {

	private GameObject[] espawns;
	private int randomint;
	private int spawnamount;
	public GameObject enemy1;
	public GameObject enemy2;
	private int spoint;
	public int levelinc = 1;
	public int levelchoice = 10;
	public GUIText currentlevel;

	// Use this for initialization
	void Start () {
		espawns = GameObject.FindGameObjectsWithTag("ERespawn");
		spawnamount = espawns.Length;
	}
	
	// Update is called once per frame
	void Update () {
	
		int enemyamount;
	

		enemyamount = GameObject.FindGameObjectsWithTag("Enemy").Length;
		if( enemyamount == 0)
		{

			if(levelinc ==levelchoice)
			{
				for(int i=0;i<=levelinc;i++){
					spoint = Randompoint(spoint);
					Instantiate (enemy1,espawns[spoint].transform.position,Quaternion.identity);
					spoint = Randompoint(spoint);
					Instantiate (enemy2,espawns[spoint].transform.position,Quaternion.identity);
					}
			}
				else 
			{
			
				currentlevel.text = "Level: "+ levelinc;

			for(int i=0;i<=levelinc;i++){
				spoint = Randompoint(spoint);
			Instantiate (enemy1,espawns[spoint].transform.position,Quaternion.identity);
				spoint = Randompoint(spoint);
			Instantiate (enemy2,espawns[spoint].transform.position,Quaternion.identity);
			
				}
				levelinc++;
			}
		}
	}

	int Randompoint (int num1){

		int ret =0;
		ret = Random.Range (0,spawnamount);
		return ret;

	}

}
