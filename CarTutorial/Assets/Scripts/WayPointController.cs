using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//[ExecuteInEditMode()]

public class WayPointController : MonoBehaviour {

	private ArrayList transforms; //easily access waypoint transforms
	private Vector3 firstPoint;   //store our first waypoint here so we can loop around a path
	private float distance; 	  //used to calc distance between waypoints
	private Transform tempTrans;  //temp holder for transform
	private int tempIndex; 		  //temp holder for a waypoint index
	private int totalTransforms;  //total amount of waypoints/transforms
	private Vector3 currentPos;   //Current position of the waypoint
	private Vector3 lastPos; 	  //last waypoint position car was at
	private Vector3 lastWaypoint; 
	public Text lapText;
	public int lapCount;

	// Use this for initialization
	void Start () {

		//make sure we grab all the transforms for each waypoint on start
		GetTransforms ();
	}

	/*void update() {
		updateLap ();
	}*/
	
	void OnDrawGizmos() {

		//if we dont have any transforms for waypoints, then grab them all
		if (transforms == null)
			GetTransforms ();

		//make sure that we have more than one transform in our list, otherwise we cant draw lines between them
		if (transforms.Count < 2)
			return; 

		//draw our path around the track, first grab the position of our first waypoint
		//so the line has a starting point
		tempTrans = (Transform) transforms [0];
		lastPos = tempTrans.position; 

		//we point each waypoint to the next...so that we can use this rotation data to find out when the	
		//player is going the wrong way, or to reposition the player after a reset. This is the temp reference to the 
		//transform we want to point towards. 
		Transform pointT = tempTrans;

		//This is the first waypoint and we want to store it to the last position so we can close our path later.
		firstPoint = lastPos;

		Gizmos.color = new Color (1, 0, 0, 1);

		//loop through all the waypoints, and draw lines between them
		for (int i = 1; i < transforms.Count; i++) {
			
			tempTrans = (Transform) transforms [i];

			//grab the current waypoints position
			currentPos = tempTrans.position;

			//draw a line between last waypoint and current one
			Gizmos.DrawLine (lastPos, currentPos);

			//draw our first waypoint
			Gizmos.DrawCube (firstPoint, new Vector3 (2, 2, 2));

			//draw all other waypoints
			Gizmos.DrawCube (currentPos, new Vector3 (2, 2, 2));

			//point our last transform at the latest position
			pointT.LookAt (currentPos);

			//update our "last" waypoint to become this one as we move on to the next
			lastPos = currentPos; 

			//update the current pointing transform
			pointT = (Transform) transforms [i];

			//lastWaypoint = (Transform)transforms [i];
		}

		//close the path and visualize the line around the entire track.
		Gizmos.DrawLine (currentPos, firstPoint);

	}


	void GetTransforms() {

		//store all transforms for waypoints in the arraylist
		transforms = new ArrayList ();

		//now go through any transforms "under" this transform so all child objects can act as wasypoints
		//in our arraylist
		foreach (Transform t in transform) {
			transforms.Add(t);
		}

		totalTransforms = transforms.Count;
	}

	Transform GetWaypoint(int index) {
		
		if (transforms == null)
			GetTransforms ();

		if (index > transforms.Count)
			return null; 

		return (Transform) transforms [index];
	}

	int GetTotal() {
		return totalTransforms;
	}

	/*void updateLap() {
		if (lastPos = lastWaypoint)
			lapCount++;
		lapText.text = lapCount.ToString (); 
	}
		*/
}
