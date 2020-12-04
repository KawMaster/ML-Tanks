/*** <ML-TANKS CODE> ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFlock : MonoBehaviour{

	private List<GameObject> tanks;

	public void Start(){
		tanks = new List<GameObject>();
	} 

	public void addTank(GameObject tank){
		tanks.Add(tank);
	}

	public GameObject getTank(int i){
		if(i < tanks.Count){
			return tanks[i];
		}

		else{
			return null;
		}
	}
}
