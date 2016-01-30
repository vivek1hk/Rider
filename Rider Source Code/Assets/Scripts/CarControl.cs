using UnityEngine;
using System.Collections;

public class CarControl : MonoBehaviour {
	public WheelCollider wheelFR;
	public WheelCollider wheelFL;
	public WheelCollider wheelRR;
	public WheelCollider wheelRL;
	public float maxTorque=50f;
	public Transform centerOfMass;	
	
	// Use this for initialization
	void Start () {
		
			rigidbody.centerOfMass = centerOfMass.localPosition;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		wheelRR.motorTorque= maxTorque*Input.GetAxis("Vertical");
		wheelRL.motorTorque= maxTorque*Input.GetAxis("Vertical");
		wheelFL.steerAngle= 10*Input.GetAxis("Horizontal");
		wheelFR.steerAngle= 10*Input.GetAxis("Horizontal");
		

	
	}
}
