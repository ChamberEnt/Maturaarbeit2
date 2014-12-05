using UnityEngine;
using System.Collections;
using System;

public class EnemyMovement : MonoBehaviour {

	/* ACHTUNG! im moment nur rotation, werde noch bewegung mit erweitertem Skript machen (extends) 

	 vermutlich brauche ich auch nicht zwei IEnumerators. Ich hatte nur angst, dass sich die Coroutines ineinander "Stapeln" was eigentlich nicht passieren sollte 
	*/
	public float turnSpeed; //Drehgeschwindigkeit (in s/90Grad )
	public Transform myTransform; //Position + Rotation + Grösse
	private bool turning; //ob das Objekt sich dreht
	public float rotationAngle; //Liste mit den Drehwinkeln
	private Quaternion startRot; //Anfangsrotation
	private float changeDirection;
	
	void Start ()
	{
		turning = true;
		myTransform = transform;
		startRot = myTransform.rotation;
		changeDirection = -1;
	}

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
