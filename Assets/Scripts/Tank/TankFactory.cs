/*** <ML-TANKS CODE> ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents.Policies;
public class TankFactory : MonoBehaviour{

	public GameObject tankPrefab;
	public GameObject previousTankPrefab;
	public int TankCount;
	public int SpawnRadius;
	public int previousTankCount;
	public int previousTankOffset;
	public GameObject ai;

	private List<TankML> previousTanks = new List<TankML>();
	private List<TankML> currentTanks = new List<TankML>();


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

	void SpawnTanks()
	{
		for (int i = 0; i < TankCount; i++)
		{
			var position = transform.position + Quaternion.Euler(0, i * 360 / TankCount, 0) * Vector3.forward * SpawnRadius;
			var rotation = Quaternion.Euler(0, i * 360 / TankCount, 0);
			var tank = Instantiate(tankPrefab, position, rotation, transform);
            var tankComponent = tank.GetComponent<TankML>();

			tankComponent.StartPosition = position;
			tankComponent.StartRotation = rotation;
		}
	}


}
