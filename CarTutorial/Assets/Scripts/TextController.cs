using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;

[RequireComponent(typeof (CarController))]
public class TextController : MonoBehaviour {

	Text Speedometer;
	CarController car = new CarController(); 

	// Use this for initialization
	void Start () {
		Speedometer = GetComponent<Text> ();
		car = GetComponent<CarController> (); 
	}
	
	// Update is called once per frame
	void Update () {
		Speedometer.text = car.CurrentSpeed + "";
	}
}
