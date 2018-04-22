using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FleetRotator : MonoBehaviour {
	public GameObject fleetRepresentation;
	public Vector3 start;
	public Vector3 end;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		/*float angle = Mathf.Rad2Deg * Mathf.Atan2(-(end-start).x, (end-start).y);
		Debug.Log(angle);
		fleetRepresentation.transform.rotation = Quaternion.Euler(0, 0, angle);//Quaternion.LookRotation(end-start, Vector3.up);*/
	}
}
