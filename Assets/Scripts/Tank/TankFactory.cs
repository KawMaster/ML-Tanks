using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFactory : MonoBehaviour{

	public GameObject tankPrefab;
	public GameObject ai;

	// create tank
	public GameObject createTank(int[] specs, SimObserver observer, string name){
		GameObject newTank = Instantiate(tankPrefab);

		newTank.GetComponent<TankHealth>().SetHealth((float)specs[0]);
		newTank.GetComponent<TankHealth>().name = name;
		newTank.GetComponent<TankMovement>().SetSpeed((float)specs[1]);
		newTank.GetComponent<TankShooting>().SetStrength((float)specs[2]);
		newTank.GetComponent<TankShooting>().SetStrength((float)specs[2]);
		newTank.GetComponent<TankObservable>().AddObserver(observer);

		newTank.GetComponent<TankObservable>().Notify(name + " just initialized.");

		return newTank;
	}
}
