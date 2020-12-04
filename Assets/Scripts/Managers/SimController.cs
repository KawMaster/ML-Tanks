/*** <ML-TANKS CODE> ***/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimController : MonoBehaviour {

	public UnityEngine.UI.InputField countField1;
	public UnityEngine.UI.InputField strengthField1;
	public UnityEngine.UI.InputField speedField1;
	public UnityEngine.UI.InputField healthField1;
	public UnityEngine.UI.InputField countField2;
	public UnityEngine.UI.InputField strengthField2;
	public UnityEngine.UI.InputField speedField2;
	public UnityEngine.UI.InputField healthField2;

	private SimData data;

	public void Start(){
		data = new SimData();
	}

	private int CheckRange(int input){
		if(input > 5){
			input = 5;
		}
		if(input < 1){
			input = 1;
		}
		return input;
	}

	public void setCountField1(){
		int input = Int32.Parse(countField1.text);
		input = CheckRange(input);
		countField1.text = input.ToString();
	}

	public void setCountField2(){
		int input = Int32.Parse(countField2.text);
		input = CheckRange(input);
		countField2.text = input.ToString();
	}	

	public void setStrengthField1(){
		int input = Int32.Parse(strengthField1.text);
		input = CheckRange(input);
		strengthField1.text = input.ToString();
	}

	public void setStrengthField2(){
		int input = Int32.Parse(strengthField2.text);
		input = CheckRange(input);
		strengthField2.text = input.ToString();
	}

	public void setSpeedField1(){
		int input = Int32.Parse(speedField1.text);
		input = CheckRange(input);
		speedField1.text = input.ToString();
	}

	public void setSpeedField2(){
		int input = Int32.Parse(speedField2.text);
		input = CheckRange(input);
		speedField2.text = input.ToString();
	}

	public void setHealthField1(){
		int input = Int32.Parse(healthField1.text);
		input = CheckRange(input);
		healthField1.text = input.ToString();
	}

	public void setHealthField2(){
		int input = Int32.Parse(healthField2.text);
		input = CheckRange(input);
		healthField2.text = input.ToString();
	}

	public void SetSimData(){
		data.SetTankCount(Int32.Parse(countField1.text),0);
		data.SetTankCount(Int32.Parse(countField2.text),1);

		data.SetTankSpecs(new int[]{Int32.Parse(healthField1.text),
									Int32.Parse(speedField1.text),
									Int32.Parse(strengthField1.text)}, 0);
		data.SetTankSpecs(new int[]{Int32.Parse(healthField2.text),
									Int32.Parse(speedField2.text),
									Int32.Parse(strengthField2.text)}, 1);
	}

	public SimData GetData(){
		return data;
	}
}
