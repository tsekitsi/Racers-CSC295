using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class StatisticalMenuBehaviourScript : MonoBehaviour {


    static public int selectedTireIndex;
    static public int selectedSuspensionInde;

    public void ChangeScene()
    {
        //todo: get selected car
          
        //get selected tire
        GameObject tireMenuCanvas = GameObject.Find("TireDropdown");
        Dropdown[] tireDropDownComponent = tireMenuCanvas.GetComponents<Dropdown>();
        int selectedTireIndex = tireDropDownComponent[0].value;

        //get selected suspension
        GameObject suspensionMenuCanvas = GameObject.Find("SuspensionDropdown");
        Dropdown[] suspensionDropDownComponent = suspensionMenuCanvas.GetComponents<Dropdown>();
        int selectedSuspensionIndex = suspensionDropDownComponent[0].value;

       // int topSpeed = PlayerPrefs.GetInt("score");
        int topSpeed = 10;
        // Store value on a constante "score"
        PlayerPrefs.SetInt("MaxSpeed", topSpeed);

        Application.LoadLevel("RaceScene");

    }
}
