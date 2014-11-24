﻿using UnityEngine;
using System.Collections;
using System;

public class EnemyMovement : MonoBehaviour {

	/* ACHTUNG! im moment nur rotation, werde noch bewegung mit erweitertem Skript machen (extends) 

	 vermutlich brauche ich auch nicht zwei IEnumerators. Ich hatte nur angst, dass sich die Coroutines ineinander "Stapeln" was eigentlich nicht passieren sollte 
	*/





	public static bool startBool; // um bewegung des Gegners zu starten auf true setzen
	public float turnSpeed; //Drehgeschwindigkeit (in s/90Grad )
	public static Transform myTransform; //Position + Rotation + Grösse
	private bool turning; //ob das Objekt sich dreht
	public float[] turningPath = new float[4]; //Liste mit den Drehwinkeln
	private int patroullienZaehler = 0; //Zähler um durch die oberen Listen zugehen
	private Quaternion startRot; //Anfangsrotation
	private Quaternion oldRotation; //Rotation an der das erste mahl gelaufen wurde

//	public float moveSpeed; //Bewegunsgeschwindigkeit
//	public FauxGravityAttractor attractor; //Planet/Level
//	private bool isGrounded; //ob das Objekt den Boden berührt
//	private bool moving; //ob das Objekt sich fortbewegt
//	public float[] walkingPath = new float[4]; //Liste mit den Laufdistanzen
//	private Vector3 startPos; //Anfangsposition
//	private Vector3 oldPosition; //Position an der das letzte mahl gedreht wurde



	void Start () {
		startBool = false;
		turning = false;
//		moving = false;

//		rigidbody.useGravity = false;
//		rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		myTransform = transform;
		//StartCoroutine(WalkTimer (2));
		//StartCoroutine(TurnTimer (180));
//		walkingPath[0] = 1;
//		walkingPath[1] = 1;
//		walkingPath[2] = 1;
//		walkingPath[3] = 1;
//
//
//		turningPath[0] = 90;
//		turningPath[1] = 180;
//		turningPath[2] = 270;
//		turningPath[3] = 180;



		//StartCoroutine (WalkTimer (walkingPath[0]));


	}

	void Update () {

		if (startBool)
		{
//			startPos = myTransform.position;
			startRot = myTransform.rotation;
//			StartCoroutine (WalkTimer (walkingPath[0]));
			StartCoroutine (TurnTimer (turningPath[0]));
		}
	}

	void FixedUpdate () {

//		Ray ray;
//		RaycastHit hit;
//		ray = new Ray(myTransform.position, -myTransform.position); // direction of ray
//		Physics.Raycast(ray, out hit); // cast ray downwards
//		
//		//Debug.Log ("hit.distance "+hit.distance);
//		Debug.DrawLine (transform.position, hit.point, Color.black);
//		
//		if (hit.distance <= 1f) //MaxAbstand Boden-Körper
//		{
//			isGrounded = true;
//		}
//		else
//		{
//			isGrounded = false;
//		}
//		//Debug.Log ("isGrounded: "+isGrounded);


//		//aus: https://www.youtube.com/watch?v=gHeQ8Hr92P4)
//		if (attractor)
//		{
//			attractor.Attract(myTransform, isGrounded);
//		}
//
//		if (!moving && isGrounded)
//		{
//			rigidbody.velocity = Vector3.zero;
//			rigidbody.angularVelocity = Vector3.zero;
//		}
//
//		Debug.DrawLine(myTransform.position, myTransform.position + new Vector3(0 ,0.1f ,0), Color.black, 50);
//
//		if (moving)
//		{
//			if (Vector3.SqrMagnitude(oldPosition - myTransform.position) <= (3.95f/2)*moveSpeed) //ACHTUNG 3.95f müssen angepasst werden!!! ist die distanz, irgendwie aus moveSpeed und walkTime (also walkingPath[patroullienZaehler]) berechenen
//			{
//				rigidbody.MovePosition(myTransform.position + myTransform.forward.normalized * moveSpeed * Time.deltaTime);
//			}
//		}
		
		if (turning)
		{
			if(Quaternion.Angle(myTransform.rotation, oldRotation) < turningPath[patroullienZaehler])
			{
				if (turningPath[patroullienZaehler] > 180)
				{
					if(Quaternion.Angle(myTransform.rotation, oldRotation) <= 360 - turningPath[patroullienZaehler])
					{
						transform.RotateAround(myTransform.position, -myTransform.position, turnSpeed * Time.deltaTime * 90f);
					}
				}
				else
				{
					transform.RotateAround(myTransform.position, myTransform.position, turnSpeed * Time.deltaTime * 90f);
				}
			}
		}
		
	}
	

//	IEnumerator WalkTimer(float walkTime)
//	{
//		startBool = false;
//		oldPosition = myTransform.position;
//		moving = true;
//		yield return new WaitForSeconds(walkTime);
//		moving = false;
//
//		if(turningPath[patroullienZaehler] > 180)
//		{
//			StartCoroutine(TurnTimer (360 - turningPath[patroullienZaehler]));
//		}
//		else
//		{
//			StartCoroutine(TurnTimer (turningPath[patroullienZaehler]));
//		}
//	}
//	

	IEnumerator TurnTimer(float angle)
	{
		oldRotation = myTransform.rotation;
		turning = true;
		double p = angle/(90f*turnSpeed);
		Debug.Log("Time TT1: "+ p);
		yield return new WaitForSeconds(angle/(90f*turnSpeed));
		turning = false;
		patroullienZaehler =  (patroullienZaehler+1)%(turningPath.Length);

		if (patroullienZaehler == 0)
		{
			//myTransform.position = startPos;
			myTransform.rotation = startRot;
		}

//		StartCoroutine(WalkTimer (walkingPath[patroullienZaehler]));

		//Debug.Log ("TT1: "+patroullienZaehler);
		if(turningPath[patroullienZaehler] > 180)
		{
			StartCoroutine(TurnTimer (360 - turningPath[patroullienZaehler]));
		}
		else
		{
			StartCoroutine(TurnTimer2 (turningPath[patroullienZaehler]));
		}
	}

	IEnumerator TurnTimer2(float angle)
	{
		oldRotation = myTransform.rotation;
		turning = true;
		double p = angle/(90f*turnSpeed);
		Debug.Log("Time TT2: "+ p);
		yield return new WaitForSeconds(angle/(90f*turnSpeed));
		turning = false;
		patroullienZaehler =  (patroullienZaehler+1)%(turningPath.Length);
		
		if (patroullienZaehler == 0)
		{
			//myTransform.position = startPos;
			myTransform.rotation = startRot;
		}

//		StartCoroutine(WalkTimer (walkingPath[patroullienZaehler]));

		//Debug.Log ("TT2: "+patroullienZaehler);

		if(turningPath[patroullienZaehler] > 180)
		{
			StartCoroutine(TurnTimer (360 - turningPath[patroullienZaehler]));
		}
		else
		{
			StartCoroutine(TurnTimer (turningPath[patroullienZaehler]));
		}
	}

	/*
	public void SetStartBool(bool sB)
	{
		startBool = sB;
	}
	*/

}
