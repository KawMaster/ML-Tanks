using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimManager : MonoBehaviour {

	private SimController simController;
	private Simulation simRefrence;
	private SimData data;
	private Scene currentScene;
	private int sceneIndex;

	private bool started;

	void Awake(){
    	DontDestroyOnLoad(transform.gameObject);
	}

	public void Start(){
		// default simdata
		data = new SimData();
		data.SetTankCount(1,0);
		data.SetTankCount(1,1);
		data.SetTankSpecs(new int[]{1,1,1}, 0);
		data.SetTankSpecs(new int[]{1,1,1}, 1); 
		
		started = false;
	}

	public void Update(){
		// check if in simulation and started 
		currentScene = SceneManager.GetActiveScene();
		sceneIndex = currentScene.buildIndex;
		if(started == false && sceneIndex == 1){
			StartSimulation();
			started = true;
		}
	}

	public void LoadSimulationScene(){
		Transform Canvas = GameObject.Find("Canvas").transform;
		foreach (Transform child in Canvas){
			if (child.name == "SimDataController"){
				simController = child.GetComponent<SimController>();
				SetData(simController.GetData());
			}
		}

		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}

	public void StartSimulation(){
		simRefrence = GameObject.Find("Simulation").GetComponent<Simulation>();

		while(simRefrence.init == false){
			// makeshift mutex
		}

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
