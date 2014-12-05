using UnityEngine;
using System.Collections;

public class EnemyAwareness : MonoBehaviour {

	public float fieldOfViewDegrees; //Sichtfeld in Grad
	public float visibilityDistance; //Sichtweite
	private Transform myTransform; //Position + Rotation + Grösse

	void Start ()
	{
		myTransform = transform;
		fieldOfViewDegrees = 58;
		visibilityDistance = 4.15f;
	}

	void Update () {
		Vector3 localForward = transform.forward*visibilityDistance+transform.position;
		Debug.DrawLine(transform.position, localForward, Color.green);
	}

	void FixedUpdate()
	{
		if(Level1.returnEnemysEnabeled())
		{
			CanSeePlayer();
		}
	}

	private void CanSeePlayer()
	{
		GameObject Player = GameObject.Find("Player");
		RaycastHit hit;
		Vector3 rayDirection = (Player.transform.position - myTransform.transform.position*1.01f).normalized;
		Physics.Raycast(myTransform.position*1.01f, rayDirection, out hit);

		Debug.DrawLine(myTransform.position*1.01f, hit.point, Color.cyan);
		if ((Vector3.Angle(rayDirection, myTransform.forward)) <= fieldOfViewDegrees * 0.5f && hit.distance != 0)
		{
			if (hit.distance <= visibilityDistance)
			{
				Debug.DrawLine(myTransform.position, hit.point, Color.red);
				if(hit.transform.CompareTag("Player"))
				{
					Level1.setCanSeePlayer(true);
				}
			}
		}
	}
}
