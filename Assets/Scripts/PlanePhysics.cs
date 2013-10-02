using UnityEngine;
using System.Collections;

public class PlanePhysics : MonoBehaviour {

	// Use this for initialization
	void Start () {
		collider.material.dynamicFriction = 1;
		collider.material.frictionCombine = PhysicMaterialCombine.Multiply;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
