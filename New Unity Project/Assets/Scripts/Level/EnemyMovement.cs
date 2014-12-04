using UnityEngine;
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
	private int patroullienZaehler; //Zähler um durch die oberen Listen zugehen
	private Quaternion startRot; //Anfangsrotation
	private Quaternion oldRotation; //Rotation an der das erste mahl gelaufen wurde
	
	void Start ()
	{
		patroullienZaehler = 0;
		startBool = false;
		turning = false;
		myTransform = transform;
	}

	void Update ()
	{

		if (startBool)
		{
			startRot = myTransform.rotation;
			StartCoroutine (TurnTimer (turningPath[0]));
		}
	}

	void FixedUpdate () 
	{
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
			myTransform.rotation = startRot;
		}
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
			myTransform.rotation = startRot;
		}

		if(turningPath[patroullienZaehler] > 180)
		{
			StartCoroutine(TurnTimer (360 - turningPath[patroullienZaehler]));
		}
		else
		{
			StartCoroutine(TurnTimer (turningPath[patroullienZaehler]));
		}
	}
}
