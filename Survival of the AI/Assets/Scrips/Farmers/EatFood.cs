using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour {
	private Farmer_Movement parentScript;
	// Use this for initialization
	void Start () {
		parentScript = this.GetComponentInParent<Farmer_Movement> ();
	}
	
	void OnTriggerEnter2D(Collider2D col){
		parentScript.recieveTriggers ("eat", col);
	}
}
