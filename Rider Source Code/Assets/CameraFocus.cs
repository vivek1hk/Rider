using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F1))
		{
		   camera.depth = Camera.main.depth + 1;
		}	
	}
}
