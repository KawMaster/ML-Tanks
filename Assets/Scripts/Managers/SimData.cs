
/*** <ML-TANKS CODE> ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimData 
 {
 	private SideData[] sideData;
 	// agents data

	// Use this for initialization
	public SimData() {
		sideData = new SideData[2];
		sideData[0] = new SideData();
		sideData[1] = new SideData();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int[] GetTankCounts(){
		return new int[2] {sideData[0].GetTankCount(), sideData[1].GetTankCount()};
	}

	public int[,] GetTankSpecs(){
		return new int[,] {{sideData[0].GetTankSpecs()[0], sideData[0].GetTankSpecs()[1], sideData[0].GetTankSpecs()[2]}, 
							{sideData[1].GetTankSpecs()[0], sideData[1].GetTankSpecs()[1], sideData[1].GetTankSpecs()[2]}};
	}

	public void SetTankCount(int input, int side){
		sideData[side].SetTankCount(input);
	}

	public void SetTankSpecs(int[] input, int side){
		int length = sideData[side].GetTankSpecs().Length;
		for(int i = 0; i < length; i++){
			sideData[side].SetTankSpecs(input);
		}
	}
}

class SideData
{
	private int tankCount;
	private int[] tankSpecs;

	public SideData(){
		tankCount = 0;
		tankSpecs = new int[3] {0,0,0};
	}

	public int GetTankCount(){
		return tankCount;
	}

	public int[] GetTankSpecs(){
		return tankSpecs;
	}

	public void SetTankCount(int input){
		tankCount = input;
	}

	public void SetTankSpecs(int[] input){
		for(int i = 0; i < tankSpecs.Length; i++){
			tankSpecs[i] = input[i];
		}
	}

	// Debug purposes
	public string Output(){
		return "tankCount: " + tankCount 
			+ " tankSpecs: " + tankSpecs[0] + ", "
			 + tankSpecs[1] + ", " 
			 + tankSpecs[2];
	}
}
