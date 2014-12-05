using UnityEngine;
using System.Collections;

public class CharacterScaler : MonoBehaviour {
	
	private Transform myTransform;
	private static float multiplyer;
	//private static float currentMultiplyer;
	private float startMagnitude;

	void Start ()
	{
		myTransform = transform;
		startMagnitude = myTransform.position.magnitude;
		multiplyer = 1;
	}

	void FixedUpdate ()
	{
		float xyz = myTransform.position.magnitude/startMagnitude;
		myTransform.localScale = new Vector3(xyz, 1, xyz);
		//multiplyer = myTransform.position.magnitude/startMagnitude;
		//PlayerController.multiplyAll(multiplyer);
		//Debug.Log ("multiplyer: "+(myTransform.position.magnitude/startMagnitude));
		/*
		multiplyer = myTransform.position.magnitude/startMagnitude;
		if(currentMultiplyer >= multiplyer*1.1 || currentMultiplyer <= multiplyer*0.9)
		{
			Debug.Log ("new currentMultiplyer set: "+multiplyer);
			currentMultiplyer = multiplyer;
			PlayerController.multiplyAll(multiplyer);
		}
		*/
	}

	public static float returnMultiplyer()
	{
		return multiplyer;
	}
}