using UnityEngine;
using System.Collections;

public class CameraHeight : MonoBehaviour {

	private float groundLevel;
	private Transform myTransform;
	
	void Start ()
	{
		myTransform = transform;
		groundLevel = myTransform.position.magnitude;
	}

	void Update ()
	{
		myTransform.localPosition = new Vector3(0, groundLevel-PlayerController.returnMyPosition().magnitude, 0);
	}

	void ChangeHeight()
	{

	}
}