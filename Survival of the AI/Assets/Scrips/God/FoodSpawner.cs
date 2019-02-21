using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {
	public GameObject food;
	public int foodCount;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnFood", 0f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void spawnFood(){
		if(foodCount < 50){
			int ranx = Random.Range (-50, 50);
			int rany = Random.Range (-37, 37);
			Vector3 pos = new Vector3 (ranx * 10, rany * 10, -1);
			Instantiate (food, pos, Quaternion.identity);
			foodCount ++;
		}
	}
}
