using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeFood : MonoBehaviour {
	private Farmer_Movement parentScript;
	// Use this for initialization
	void Start () {
		parentScript = this.GetComponentInParent<Farmer_Movement> ();
	}

	void OnTriggerStay2D(Collider2D col){
		if (this.parentScript.gameObject.tag == "Blue_Farmer") {
			if (col.transform.position.x <= 0) {
				parentScript.recieveTriggers ("see", col);
			}
		} else if (this.parentScript.gameObject.tag == "Red_Farmer") {
			if (col.transform.position.x >= 0) {
				parentScript.recieveTriggers ("see", col);
			}
		}
	}
}
