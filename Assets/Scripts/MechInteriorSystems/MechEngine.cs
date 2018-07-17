using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechEngine : MonoBehaviour {

	public bool engineRunning;
	public float throttleAmmount;
	public float breakAmmount;
	public float setRPM;
	public float currentRPM;
	public float powerMultiplier;
	public float heatMultiplier;
	public float heatDissipation;

	public float currentHeat;
	public float maxHeat;

	public float ventingAmmount;
	public float coolingValue; //how much each charge of coolant cools the engine.
	public int coolantAmmount;

	// Use this for initialization
	void Start () {
		coolantAmmount = 50;
		coolingValue = 10;
		setRPM = 0;
		ventingAmmount = 0; //unvented = 0, with ventilation and cooling might be something else.
		throttleAmmount = 5;
		breakAmmount = 5;
		powerMultiplier = 1f;
		heatMultiplier = 1;
		heatDissipation = 5;
	}
	
	// Update is called once per frame
	void Update () {
		//check to see if set RPM is higher or lower than Desired RPM
		//make the current RPM go either up or down o match the Desired RPM
		if( currentRPM < setRPM && engineRunning == true ){
			currentRPM = currentRPM + throttleAmmount * Time.deltaTime;
		}
		else if (currentRPM > setRPM && engineRunning == true){
			currentRPM = currentRPM - breakAmmount * Time.deltaTime;
		}
		
		//------------------------------------------
		//heat stuff
		//------------------------------------------
		//heat in = currentRPM * heatMultiplier
		//heat out = ventingAmmount + heatDissipation
		//current heat = heat in - heat out
		//currentHeat = currentRPM*heatMultiplier - heatDissipation - ventingAmmount;
		//if (currentHeat > maxHeat){powerMultiplier = 0.7f;}
		//if (currentHeat < maxHeat){powerMultiplier = 1;}

		//this isn't instant, but takes a second or so to power up/down.
		//keypress stuff for mech turn off and on
		//keypress for cooling/ventilation stuff
		if (Input.GetKey(KeyCode.Alpha1) && engineRunning==false){EngineStart();}
		//turn off engine if press 0 again:
		if (Input.GetKey(KeyCode.Alpha0) && engineRunning==true){EngineStop();}
		//tryck på 2 för att sätta motorn till 25%
		if (Input.GetKey(KeyCode.Alpha2) && engineRunning==true){Engine25Percent();}
		//tryck 3 för att sätta motorn till 50%
		if (Input.GetKey(KeyCode.Alpha3) && engineRunning==true){Engine50Percent();}
		//tryck 4 för att sätta motorn 75%
		if (Input.GetKey(KeyCode.Alpha4) && engineRunning==true){Engine75Percent();}
		//tryck 5 för att sätta motorn till 100%
		if (Input.GetKey(KeyCode.Alpha5) && engineRunning==true){Engine100Percent();}
		//tryck 9 för att kyla motorn
		if (Input.GetKey(KeyCode.Alpha9) &&engineRunning==true){EngineCoolantFlush();}
	}

	void EngineStart(){
		//engine Running = true;
		engineRunning=true;
		setRPM=10;
	}
	void EngineStop(){
		//engineRunning = false;
		engineRunning=false;
		setRPM=0;
		//engine winds down to 0 RPM
	}
	void Engine25Percent(){
		//Sets Engine effect to 25%
		setRPM = 25;
	}
	void Engine50Percent(){
		//Sets Engine effect to 50%
		setRPM = 50;
	}
	void Engine75Percent(){
		//Sets engine effect to 75%
		setRPM = 75;
	}
	void Engine100Percent(){
		//sets engine effect to 100%
		setRPM = 100;
	}
	void EngineCoolantFlush(){
		coolantAmmount--;
		currentHeat = currentHeat - coolantAmmount;
	}
}
