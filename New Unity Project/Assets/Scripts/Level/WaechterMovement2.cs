using UnityEngine;
using System.Collections;

public class WaechterMovement2 : MonoBehaviour {
	
	private int anzahlPunkte;
	private GameObject[] punkte;
	private int zaehler;
	private float turnSpeed;
	private Transform myTransform;
	private float moveSpeed;
	private float maxSpeed;
	private bool turning;
	private bool walking;
	private bool startTurning;
	private bool isGrounded;
	
	void Awake () {
		turnSpeed = 1;
		moveSpeed = 5;
		myTransform = transform;
		maxSpeed = moveSpeed*2;
		zaehler = 0;
		walking = false;
		//		punkte = Level1.returnPunkte();
		//		anzahlPunkte = punkte.GetLength(0);
		//		myTransform.position = punkte[zaehler].GetComponent<Transform>().position;
		//		startTurning = true;
		//		turning = true;
		
	}
	
	void Update ()
	{
		if (punkte != null)
		{
			if ((punkte[zaehler].GetComponent<Transform>().position - myTransform.position).magnitude >= (punkte[zaehler].GetComponent<Transform>().position - (punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position)).magnitude)
			{
				zaehler = (zaehler+1)%anzahlPunkte;
				myTransform.position = punkte[zaehler].GetComponent<Transform>().position;
				startTurning = true;
				turning = true;
				walking = false;
				rigidbody.velocity = Vector3.zero;
			}
			Ray ray;
			RaycastHit hit;
			ray = new Ray(myTransform.position, -myTransform.position); // origin, direction of ray
			Physics.Raycast(ray, out hit); // cast ray downwards
			if (hit.distance <= 0.1f)
			{
				isGrounded = true;
			}
			else
			{
				isGrounded = false;
			}
		}
		
	}
	
	void FixedUpdate()
	{
		if(startTurning)
		{
			turn ();
			startTurning = false;
			//StartCoroutine(turnTimer((Vector3.Angle(myTransform.forward,punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position-myTransform.position)/90)/(turnSpeed/16)));
		}
		else if (turning)
		{
			turn ();
			//Debug.Log (Vector3.Angle(myTransform.forward,punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position)+Vector3.Angle(myTransform.position, punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position));
			if(Vector3.Angle(myTransform.forward,punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position)+Vector3.Angle(myTransform.position, punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position) <= 90.2f)
			{
				turning = false;
				walking = true;
			}
		}
		else if (walking)
		{
			rigidbody.AddForce((punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position-myTransform.position).normalized*moveSpeed*10);
		}
	}
	
	IEnumerator turnTimer(float timer)
	{
		//float time = Time.time;
		yield return new WaitForSeconds(timer);
		turning = false;
		walking = true;
		StopCoroutine(turnTimer(1));
	}

	private void turn()
	{
		//Debug.Log ("myTransform.forward: "+myTransform.forward+"  Richtung: "+);
		Quaternion targetRotation = Quaternion.FromToRotation(myTransform.forward,punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position - myTransform.position) * myTransform.rotation;
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation,targetRotation,turnSpeed * Time.deltaTime );
	}
	
	public void setPunkte(GameObject[] newPunkte)
	{
		punkte = newPunkte;
		anzahlPunkte = punkte.GetLength(0);
		myTransform.position = punkte[zaehler].GetComponent<Transform>().position;
		startTurning = true;
		turning = true;
	}
	
	public bool returnIsGrounded()
	{
		return isGrounded;
	}
}
