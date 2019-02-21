using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer_Movement : MonoBehaviour {
	public GameObject god;
	public GameObject king;
	public Vector3 newFood;
	public bool smellPlan, sightPlan;
	int ran;
	public float speed;
	// Use this for initialization
	void Start () {
		speed = .25f;
		smellPlan = false;
		sightPlan = false;
		god = GameObject.FindGameObjectWithTag ("God");
		if(this.tag == "Blue_Farmer"){
			king = GameObject.FindGameObjectWithTag ("Blue_King");
		}else if(this.tag == "Red_Farmer"){
			king = GameObject.FindGameObjectWithTag ("Red_King");
		}
		increaseSpeed ();
	}

	public void increaseSpeed(){
		speed = this.GetComponent<Farmer_Skills> ().getSpeed();
		CancelInvoke ();
		InvokeRepeating ("basicMovement", 0f, speed);
	}
	
	// Update is called once per frame
	void Update () {
		ran = Random.Range (1, 5);
		if(newFood == this.transform.position){
			sightPlan = false;
			smellPlan = false;
		}
	}

	public void basicMovement(){

		if (smellPlan || sightPlan) {
			if (newFood.x > this.transform.position.x) {
				this.transform.position = new Vector3 (this.transform.position.x + 10f, this.transform.position.y, this.transform.position.z);
			} else if (newFood.x < this.transform.position.x) {
				this.transform.position = new Vector3 (this.transform.position.x - 10f, this.transform.position.y, this.transform.position.z);
			} else if (newFood.y > this.transform.position.y) {
				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 10f, this.transform.position.z);
			} else if (newFood.y < this.transform.position.y) {
				this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - 10f, this.transform.position.z);
			}
		} else {
			if (this.tag == "Blue_Farmer") {
				switch (ran) {
				case 1: 
					if (this.transform.position.y < 370) {
						this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 10f, this.transform.position.z);
					}
					break;
				case 2: 
					if (this.transform.position.x < 0) {
						this.transform.position = new Vector3 (this.transform.position.x + 10f, this.transform.position.y, this.transform.position.z);
					}
					break;
				case 3: 
					if (this.transform.position.y > -370) {
						this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - 10f, this.transform.position.z);
					}
					break;
				case 4: 
					if (this.transform.position.x > -500) {
						this.transform.position = new Vector3 (this.transform.position.x - 10f, this.transform.position.y, this.transform.position.z);
					}
					break;
				}
			}else if(this.tag == "Red_Farmer"){
				switch (ran) {
				case 1: 
					if (this.transform.position.y < 370) {
						this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 10f, this.transform.position.z);
					}
					break;
				case 2: 
					if (this.transform.position.x < 500) {
						this.transform.position = new Vector3 (this.transform.position.x + 10f, this.transform.position.y, this.transform.position.z);
					}
					break;
				case 3: 
					if (this.transform.position.y > -370) {
						this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - 10f, this.transform.position.z);
					}
					break;
				case 4: 
					if (this.transform.position.x > 0) {
						this.transform.position = new Vector3 (this.transform.position.x - 10f, this.transform.position.y, this.transform.position.z);
					}
					break;
				}
			}
		}
	}
		

	public void recieveTriggers(string sense, Collider2D col){
		if(sense == "see"){
			if (col.tag == "Food" && sightPlan == false) {
				newFood = col.gameObject.transform.position;
				sightPlan = true;
			}
		}else if(sense == "smell"){
			if (col.tag == "Food") {
				if (!sightPlan) {
					newFood = col.gameObject.transform.position;
					smellPlan = true;
				}
			}
		}
		if(sense == "lostSmell"){
			if (col.tag == "Food") {
				if (col.transform.position == newFood) {
					smellPlan = false;
				}
			}
		}
		if(sense == "eat"){
			sightPlan = false;
			smellPlan = false;
			if (col.tag == "Food"){
				king.GetComponent<King_Inventory>().food++;
				Destroy (col.gameObject);
				god.GetComponent<FoodSpawner> ().foodCount--;
			}
		}
			
	}
}
