using UnityEngine;
using System.Collections;

public class EnemyAwareness : MonoBehaviour {

	public float fieldOfViewDegrees; //Sichtfeld in Grad
	public float visibilityDistance; //Sichtweite
	private Transform myTransform; //Position + Rotation + Grösse


	// Use this for initialization
	void Start () {
		myTransform = transform;
		fieldOfViewDegrees = 58;
		visibilityDistance = 4.15f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 localForward = transform.forward*visibilityDistance+transform.position;
		Debug.DrawLine(transform.position, localForward, Color.green);
		//Debug.Log ("CanSeePlayer: "+CanSeePlayer());
	}

	void FixedUpdate()
	{
		CanSeePlayer();
	}

	private void CanSeePlayer()
	{
		//Debug.Log (Time.time);
		GameObject Player = GameObject.Find("Player");
		RaycastHit hit;
		Vector3 rayDirection = (Player.transform.position - myTransform.transform.position*1.01f).normalized;
		Physics.Raycast(myTransform.position*1.01f, rayDirection, out hit);

		Debug.DrawLine(myTransform.position*1.01f, hit.point, Color.cyan);
		if ((Vector3.Angle(rayDirection, myTransform.forward)) <= fieldOfViewDegrees * 0.5f)
		{
			//Debug.Log (hit.distance);
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
