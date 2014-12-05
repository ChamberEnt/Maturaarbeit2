using UnityEngine;
using System.Collections;

public class CameraHeight : MonoBehaviour {

	private static float groundLevel;
	private static Transform myTransform;
	
	void Start ()
	{
		myTransform = transform;
		groundLevel = myTransform.position.magnitude;
	}

	void Update ()
	{
		//Debug.Log ("currentGroundLevel: "+groundLevel);
		myTransform.localPosition = new Vector3(0, groundLevel-PlayerController.returnMyPosition().magnitude, 0);
	}

	public static void setHeight(float newGroundlevel)
	{
		groundLevel = newGroundlevel;
	}
}