/*** <ML-TANKS CODE> ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour {

	public TankFactory tankFacotry;
	public Transform[] spawnPoints;
	private GameManager gameManager;
	private SimObserver simObserver;
	private TankFlock[] flocks;

	public bool init = false;

	public void Awake () {

		gameManager = gameObject.GetComponent<GameManager>();
		simObserver = gameObject.GetComponent<SimObserver>();

		flocks = new TankFlock[2];
		TankFlock newFlock0 = gameObject.AddComponent<TankFlock>() as TankFlock;
		newFlock0.Start();
		flocks[0] = newFlock0;
		TankFlock newFlock1 = gameObject.AddComponent<TankFlock>() as TankFlock;
		newFlock1.Start();
		flocks[1] = newFlock1;

		init = true;
	}

	public void InitTankFlocks(SimData simData){
		int[] tankCounts = simData.GetTankCounts(); 
		int[,] tankSpecs = simData.GetTankSpecs();

		for(int side = 0; side < 2; side++){
			int count = tankCounts[side]; 
			for(int i = 0; i < count; i++){
				// put tank in flock
				int[] specs = {tankSpecs[side,0], tankSpecs[side,1], tankSpecs[side,2]};
				GameObject newTank = tankFacotry.createTank(specs, simObserver, "Tank" + side + i);
				flocks[side].addTank(newTank);				

				// place in position
				Vector3 newPosition = spawnPoints[side].position;
				newPosition.z += (i * 3);
				newTank.transform.position = newPosition;
			}
		}

		// add tank to gamemanager
		gameManager.SetCameraTargets(flocks, tankCounts);
	}

	public TankFlock GetFlock(int input){
		return flocks[input];
	}
}