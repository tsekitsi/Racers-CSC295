using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class CarStatsBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Debug.Log(PlayerPrefs.GetInt("topSpeed"));

        GameObject gObj = GameObject.Find("CarObject");
        Debug.Log(gObj.name);
        CarController CarController = gObj.GetComponent("CarController") as CarController;


        float speed = (float) PlayerPrefs.GetInt("MaxSpeed");

        CarController.MaxSpeed = speed;
        Debug.Log(CarController.MaxSpeed);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
