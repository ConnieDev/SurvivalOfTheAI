using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army_Spawner : MonoBehaviour {
	public GameObject bFarmer;
	public GameObject rFarmer;
	public GameObject bWarrior;
	public GameObject rWarrior;
	
	// Update is called once per frame
	void Update () {
		if(this.tag == "Blue_King"){
			if (this.GetComponent<King_Inventory> ().farmers < 10) {
				if (this.GetComponent<King_Inventory> ().food > 10) {
					Instantiate (bFarmer);
					this.GetComponent<King_Inventory> ().farmers += 1;
					this.GetComponent<King_Inventory> ().food -= 10;
				}
			}
		}else if(this.tag == "Red_King"){
			if (this.GetComponent<King_Inventory> ().farmers < 10) {
				if (this.GetComponent<King_Inventory> ().food > 10) {
					Instantiate (rFarmer);
					this.GetComponent<King_Inventory> ().farmers += 1;
					this.GetComponent<King_Inventory> ().food -= 10;
				}
			}
		}
		if(this.tag == "Blue_King"){
			if (this.GetComponent<King_Inventory> ().food > 15) {
				Instantiate (bWarrior);
				this.GetComponent<King_Inventory> ().food -= 15;
			}
		}else if(this.tag == "Red_King"){
			if (this.GetComponent<King_Inventory> ().food > 15) {
				Instantiate (rWarrior);
				this.GetComponent<King_Inventory> ().food -= 15;
			}
		}
	}
}
