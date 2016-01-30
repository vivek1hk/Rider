using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	int i=-1;
	int val=1;
	
	

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x>800)
			rigidbody.AddForce(Vector3.right*-3);
		if(transform.position.x<8000 && transform.position.x>0)
			rigidbody.AddForce(Vector3.right*3);	
	}
	void  LateUpdate()
	{
		//rigidbody.AddForce(Vector3.left*5);
	}
}
