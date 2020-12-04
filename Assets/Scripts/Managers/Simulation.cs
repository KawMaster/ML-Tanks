using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour {

	public TankFactory tankFacotry;
	public Transform[] spawnPoints;
	private GameManager gameManager;
	// private SimObserver observer;
	private TankFlock[] flocks;

	public void Start () {

		gameManager = gameObject.GetComponent<GameManager>();
		// simObserver = gameObject.GetComponent<SimObserver>();

		flocks = new TankFlock[2];
		flocks[0] = new TankFlock();
		flocks[1] = new TankFlock();
	}

	public void InitTankFlocks(SimData simData){
		int[] tankCounts = simData.GetTankCounts(); 
		int[,] tankSpecs = simData.GetTankSpecs();
		
		for(int side = 0; side < 2; side++){
			int count = tankCounts[side]; 
			for(int i = 0; i < count; i++){
				int[] specs = {tankSpecs[i,0], tankSpecs[i,1], tankSpecs[i,2]};
				GameObject newTank = tankFacotry.createTank(specs);
				newTank.transform.position = spawnPoints[i].position;

				// add tank to gamemanager
				gameManager.SetCameraTargets(flocks, tankCounts);
			}
		}
	}

	public void StartSim(){
		// start gamemanager
		gameManager.StartSimulation();
	}

	public TankFlock GetFlock(int input){
		return flocks[input];
	}

	public string GetData(){
		return "wip";
	}
	
}
