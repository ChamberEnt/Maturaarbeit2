using UnityEngine;
using System.Collections;

public class CameraHeight : MonoBehaviour {

	private float groundLevel;
	private Transform myTransform;
	//private PlayerController playerController;
	
	void Start () {
		myTransform = transform;
		groundLevel = myTransform.position.magnitude;
		//playerController = GameObject.Find("Player").GetComponent("PlayerController");
	}

	void Update () {
		myTransform.localPosition = new Vector3(0, groundLevel-PlayerController.returnMyPosition().magnitude, 0);
	}

	void ChangeHeight()
	{

	}
}