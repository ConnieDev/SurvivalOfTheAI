using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScreen : MonoBehaviour {
	public GameObject statScreen;

	public Text blueTeamText;
	public Text redTeamText;

	public int bking, rking, bFarmers, rFarmers, bWarriors, rWarriors;



	// Use this for initialization
	void Start () {
		bking = 1;
		rking = 1;
		bFarmers = 1;
		rFarmers = 1;
		bWarriors = 1;
		rWarriors = 1;
	}
	
	// Update is called once per frame
	void Update () {
		blueTeamText.text = ("Blue Team Stats:\r\n- Kings: " + bking + "\r\n- Farmers: " + bFarmers + "\r\n- Warriors: " + bWarriors);
		redTeamText.text = ("Red Team Stats:\r\n- Kings: " + rking + "\r\n- Farmers: " + rFarmers + "\r\n- Warriors: " + rWarriors);
	}

	public void toggleStats(){
		if(statScreen.activeInHierarchy == true){
			statScreen.SetActive (false);
		}else if(statScreen.activeInHierarchy == false){
			statScreen.SetActive (true);
		}
	}

}
