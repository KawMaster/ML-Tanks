using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour {

	private TankFlock[] flocks;

	void Start () {
		flocks = new TankFlock[2];
		flocks[0] = new TankFlock();
		flocks[1] = new TankFlock();
	}

	public TankFlock GetFlock(int input){
		return flocks[input];
	}
	
}
