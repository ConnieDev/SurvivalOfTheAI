using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer_Skills : MonoBehaviour {
	private int level;
	public float speed;

	void Start(){
		level = 1;
		speed = 0.25f;
	}

	public void levelUp(){
		if (level < 5) {
			level++;
			speed -= 0.05f;
		}
	}

	public float getSpeed(){
		return speed;
	}
}
