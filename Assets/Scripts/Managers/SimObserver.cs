using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimObserver : MonoBehaviour {

	private string log;

	public void Start(){
		log = "";
		print("Observer initialized");
	}

	public void OnNotify(string message)
    {
        log += message + "\n";
        print(message);
    }

    public string GetData(){
    	return log;
    }
}
