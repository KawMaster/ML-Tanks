using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFactory : MonoBehaviour{

	public GameObject tankPrefab;

	// create tank
	public GameObject createTank(int[] specs){
		GameObject newTank = Instantiate(tankPrefab);

		newTank.GetComponent<TankHealth>().SetHealth((float)specs[0]);
		newTank.GetComponent<TankMovement>().SetSpeed((float)specs[1]);
		newTank.GetComponent<TankShooting>().SetStrength((float)specs[2]);

		return newTank;
	}

	// set the scripts

	// set the constants
}
