using UnityEngine;
using System.Collections;

using UnityStandardAssets.Vehicles.Car;

public class CarPropertiesPresetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject gObj = GameObject.Find("Car");
        CarController[] compnents = gObj.GetComponents<CarController>();

        //compnents[1]

        Debug.Log("ddddf");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
