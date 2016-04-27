using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class StatisticalMenuBehaviourScript : MonoBehaviour {


    static public int selectedTireIndex;
    static public int selectedSuspensionInde;

    public void ChangeScene()
    {

        int nissan = 0;
        int lamb = 0;
        int F1 = 0;

        int eagle = 0;
        int formular = 0;
        int spec = 0;

        int drift = 0;
        int offRoad = 0;

        /*
            car indecies
            0 - Nissan
            1 - Lamb
            2 - F1
        */
        //get selected car
        GameObject carMenuCanvas = GameObject.Find("CarDropdown");
        Dropdown[] carDropDownComponent = carMenuCanvas.GetComponents<Dropdown>();
        int selectedCarIndex = carDropDownComponent[0].value;

        /*
            Tire indecies
            0 - Eagle
            1 - Formular
            2 - Spec
        */
        //get selected tire
        GameObject tireMenuCanvas = GameObject.Find("TireDropdown");
        Dropdown[] tireDropDownComponent = tireMenuCanvas.GetComponents<Dropdown>();
        int selectedTireIndex = tireDropDownComponent[0].value;

        /*
            Suspension indecies
            0 - drift
            1 - off road 
        */
        //get selected suspension
        GameObject suspensionMenuCanvas = GameObject.Find("SuspensionDropdown");
        Dropdown[] suspensionDropDownComponent = suspensionMenuCanvas.GetComponents<Dropdown>();
        int selectedSuspensionIndex = suspensionDropDownComponent[0].value;
        

        switch (selectedCarIndex)
        {
            case 0:
                nissan = 1;
                break;
            case 1:
                lamb = 1;
                break;
            case 2:
                F1 = 1;
                break;
        }

        switch (selectedTireIndex)
        {
            case 0:
                eagle = 1;
                break;
            case 1:
                formular = 1;
                break;
            case 2:
                spec = 1;
                break;
        }

        switch (selectedSuspensionIndex)
        {
            case 0:
                drift = 1;
                break;
            case 1:
                offRoad = 1; ;
                break;
        }
        double speed = 350.00 + (20.00 * nissan) + (20.00 * F1)
            + (6.67 * drift) - (19 * eagle)
        - (3.33 * drift * formular)
        - (3.33 * drift * spec * nissan)
        - (6.67 * offRoad * eagle)
        + (3.33 * offRoad * formular * eagle)
        + (3.33 * offRoad * spec * nissan);

        double speedInMph = 0.621371 * speed;
        Debug.Log(speedInMph);

        int topSpeed = (int)speedInMph;
        // Store value on a constante "score"
        PlayerPrefs.SetInt("MaxSpeed", topSpeed);

        Application.LoadLevel("RaceScene");

    }
}
