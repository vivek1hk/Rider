using UnityEngine;
using System.Collections;

public class CubeMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime,0,Input.GetAxis("Vertical")*Time.deltaTime);
	}
}
