using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFlock : MonoBehaviour{

	private List<Tank> tanks;

	public void addTank(Tank tank){
		tanks.Add(tank);
	}

	public Tank getTanks(int i){
		if(i < tanks.Count){
			return tanks[i];
		}

		else{
			return null;
		}
	}
}
