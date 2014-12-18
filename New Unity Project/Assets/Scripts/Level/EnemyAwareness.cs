using UnityEngine;
using System.Collections;

public class EnemyAwareness : MonoBehaviour {

	public float fieldOfViewDegrees; //Sichtfeld in Grad
	public float visibilityDistance; //Sichtweite
	private Transform myTransform; //Position + Rotation + Grösse

	//Initialisierung
	void Start ()
	{
		myTransform = transform;
	}

	//führt CanSeePlayer() aus.
	void FixedUpdate()
	{
		if(Level1.returnEnemysEnabeled())
		{
			CanSeePlayer();
		}
	}

	//überprüft ob der Spieler im Winkel fieldOfViewDegrees vor dem Gegner steht, danach wird überprüft ob er in sichtweite (visibilityDistance) ist.
	//Stimmt beides wird im Level1 canSeePlayer auf true gesetzt.
	private void CanSeePlayer()
	{
		GameObject Player = GameObject.Find("Player");
		RaycastHit hit;
		Vector3 rayDirection = (Player.transform.position - myTransform.position*1.01f).normalized;
		Physics.Raycast(myTransform.position*1.01f, rayDirection, out hit);
		if (Vector3.Angle(rayDirection, myTransform.forward) <= fieldOfViewDegrees * 0.5f && hit.distance != 0)
		{
			if (hit.distance <= visibilityDistance)
			{
				if(hit.transform.CompareTag("Player"))
				{
					Level1.setCanSeePlayer(true);
				}
			}
		}
	}
}
