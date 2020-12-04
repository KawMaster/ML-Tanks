using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimFactory : MonoBehaviour {

	private Simulation simRefrence;

	private SimData data;

	public void Start(){
		data = new SimData();
		simRefrence = GameObject.Find("Simulation").GetComponent<Simulation>();

		simRefrence.InitTankFlocks(data);
		simRefrence.StartSim();
	}

	public SimData GetData(){
		return data;
	}

	public void SetData(SimData inputData){
		data = inputData;
	}
}
