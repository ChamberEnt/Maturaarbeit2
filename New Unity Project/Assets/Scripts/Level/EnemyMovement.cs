using UnityEngine;
using System.Collections;
using System;

public class EnemyMovement : MonoBehaviour {

	public float turnSpeed; //Drehgeschwindigkeit (in s/90Grad )
	public Transform myTransform; //Position + Rotation + Grösse
	private bool turning; //ob das Objekt sich dreht
	public float rotationAngle; //Drehwinkel
	private Quaternion startRot; //Anfangsrotation
	private float changeDirection; //in welche richtung gedreht wird, wechselt immer zwischen 1 und -1

	//Initialisierung
	void Start ()
	{
		turning = true;
		myTransform = transform;
		startRot = myTransform.rotation;
		changeDirection = -1;
	}

	//dreht die Kamera um den rotationAngle und wechselt danach die Richtung
	void FixedUpdate () 
	{
		if (turning)
		{
			transform.RotateAround(myTransform.position, myTransform.position, turnSpeed * Time.deltaTime * changeDirection);
			if(Quaternion.Angle(myTransform.rotation, startRot) >= rotationAngle)
			{
				changeDirection = 1;
			}
			else if(myTransform.rotation == startRot)
			{
				changeDirection = -1;
			}
		}	
	}
}
