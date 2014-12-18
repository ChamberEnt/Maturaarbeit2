using UnityEngine;
using System.Collections;

public class WaechterMovement2 : MonoBehaviour {
	
	private int anzahlPunkte; //anzahl der Elemente in punkte
	private GameObject[] punkte; //Patrouillenpunkte
	private int zaehler; //zähler, an welchem Patrouillenpunkt der Wächter steht
	private float turnSpeed; //Drehgeschwindigkeit
	private Transform myTransform; //Position + Rotation + Skalierung
	private float moveSpeed; //Bewegungsgeschwindigkeit
	private bool turning; // ob gedreht wird
	private bool walking; //ob gelaufen wird
	private bool startTurning; //ob angefangen wird zu drehen
	private bool isGrounded;	//ob der Wächter sich am boden befindet

	//Initialisierung
	void Awake ()
	{
		turnSpeed = 1;
		moveSpeed = 5;
		myTransform = transform;
		zaehler = 0;
		walking = false;
	}

	//überprüft ob der Punkt nach dem aktuellen Punkt in der Liste ereicht wurde und setzt den zähler eines hoch bei true(zaehler +1) und wechselt von wakling auf turning
	//überprüft ob sich der Wächter am Bofden befindet (isGrounded Update) und setzt is Grounded danach
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
			ray = new Ray(myTransform.position, -myTransform.position);
			Physics.Raycast(ray, out hit);
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

	//dreht oder läuft, je nach werte der walking und turning Parameter
	void FixedUpdate()
	{
		if(startTurning)
		{
			turn ();
			startTurning = false;
		}
		else if (turning)
		{
			turn ();
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

	//dreht
	private void turn()
	{
		Quaternion targetRotation = Quaternion.FromToRotation(myTransform.forward,punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position - myTransform.position) * myTransform.rotation;
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation,targetRotation,turnSpeed * Time.deltaTime );
	}

	//setzt eine neues Array in punkte
	public void setPunkte(GameObject[] newPunkte)
	{
		punkte = newPunkte;
		anzahlPunkte = punkte.GetLength(0);
		myTransform.position = punkte[zaehler].GetComponent<Transform>().position;
		startTurning = true;
		turning = true;
	}

	//gibt isGrounded zurück
	public bool returnIsGrounded()
	{
		return isGrounded;
	}
}
