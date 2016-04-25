using UnityEngine;
using System.Collections;

public class PlayTimer : MonoBehaviour {

    public int playtime = 0;
    public int seconds = 0;
    public int minutes = 0;
    private bool isFirstLap = true;
    private int lapCount = 1; 

    private IEnumerator PTimer()
    {
        while (true )
        {
            yield return new WaitForSeconds(1);
            playtime++;
            seconds = (playtime % 60);
            minutes = (playtime / 60) % 60; 
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "FinishLine" && isFirstLap)
        {
            StartCoroutine("PTimer");
            isFirstLap = false; 
        }

        if (lapCount > 3)
        {
            StopCoroutine("PTimer");
        }
        lapCount++;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(50, 50, 500, 50), "Laptime = " + minutes.ToString() + ":" + seconds.ToString());
    }
}
