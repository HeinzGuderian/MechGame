using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechEngine : MonoBehaviour {

	AudioSource audioData;

	public bool engineRunning;
	public float throttleAmmount = 5;
	public float breakAmmount = 5;
	public float setRPM = 0;
	public float currentRPM;
	public float powerMultiplier = 1f;
	public float heatMultiplier = 1;
	public float heatDissipation = 5;

	public float currentHeat;
	public float maxHeat;

	public float ventingAmmount = 0;
	public float coolingValue = 10; //how much each charge of coolant cools the engine.
	public int coolantAmmount = 50;

	public float engineSoundVolume = 0;

	// Use this for initialization
	void Start () {
		audioData = GetComponent<AudioSource>();
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
		if (Input.GetKey(KeyCode.Alpha2) && engineRunning==true){ SetRPM(25);}
		//tryck 3 för att sätta motorn till 50%
		if (Input.GetKey(KeyCode.Alpha3) && engineRunning==true){ SetRPM(50);}
		//tryck 4 för att sätta motorn 75%
		if (Input.GetKey(KeyCode.Alpha4) && engineRunning==true){ SetRPM(75);}
		//tryck 5 för att sätta motorn till 100%
		if (Input.GetKey(KeyCode.Alpha5) && engineRunning==true){ SetRPM(100);}
		//tryck 9 för att kyla motorn
		//if (Input.GetKey(KeyCode.Alpha9) &&engineRunning==true){EngineCoolantFlush();}

		//Engine sound volume control based on RPM:
		audioData.volume = currentRPM/101;
	}

	void EngineStart(){
		//engine Running = true;
		engineRunning=true;
		setRPM=10;
		audioData.Play(0);
		Debug.Log("Engine Started, sound playing");
	}
	void EngineStop(){
		engineRunning=false;
		setRPM=0;
		audioData.Stop();
		//engine winds down to 0 RPM
	}
    void SetRPM(int newRPM) {
        setRPM = newRPM;
    }
	void EngineCoolantFlush(){
		coolantAmmount--;
		currentHeat = currentHeat - coolantAmmount;
	}
}
