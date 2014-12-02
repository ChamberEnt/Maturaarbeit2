using UnityEngine;
using System.Collections;

public class WachterMovement2 : MonoBehaviour {

	private int anzahlPunkte;
	private GameObject[] punkte;
	private int zaehler;
	private float turnSpeed;
	private Transform myTransform;
	private float moveSpeed;
	private float maxSpeed;
	private bool turning;
	private bool startWalking;
	private bool startTurning;

	void Awake () {
		turnSpeed = 8;
		moveSpeed = 5;
		myTransform = transform;
		maxSpeed = moveSpeed*2;
		zaehler = 0;
		startWalking = false;
//		punkte = Level1.returnPunkte();
//		anzahlPunkte = punkte.GetLength(0);
//		myTransform.position = punkte[zaehler].GetComponent<Transform>().position;
//		startTurning = true;
//		turning = true;

	}

	void Update () {
		//Debug.Log (""+(punkte != null)+"  "+Time.time);
		if (punkte != null)
		{
			if ((punkte[zaehler].GetComponent<Transform>().position - myTransform.position).magnitude >= (punkte[zaehler].GetComponent<Transform>().position - (punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position)).magnitude)
			{
				zaehler = (zaehler+1)%anzahlPunkte;
				myTransform.position = punkte[zaehler].GetComponent<Transform>().position;
				startTurning = true;
				turning = true;
				startWalking = false;
				rigidbody.velocity = Vector3.zero;
				//Debug.Log ("Time: "+Time.time+"  startWalking: "+startWalking);
			}
		}
	
	}

	void FixedUpdate()
	{
		//Debug.DrawRay(myTransform.position*1.01f, myTransform.forward*10, Color.yellow);
		if(startTurning)
		{
			Quaternion targetRotation = Quaternion.FromToRotation(myTransform.forward,punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position) * myTransform.rotation;
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,targetRotation,turnSpeed * Time.deltaTime );
			startTurning = false;
			//Debug.Log (""+(Vector3.Angle(myTransform.forward,punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position-myTransform.position)));
			StartCoroutine(turnTimer(Vector3.Angle(myTransform.forward,punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position-myTransform.position)/90));
		}
		else if (turning)
		{
			Quaternion targetRotation = Quaternion.FromToRotation(myTransform.forward,punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position) * myTransform.rotation;
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,targetRotation,turnSpeed * Time.deltaTime );
		}
		else if (startWalking)
		{
			//Debug.Log (""+startWalking);
			//Debug.Log (""+(myTransform.position-punkte[zaehler+1].GetComponent<Transform>().position).normalized);
			Debug.DrawRay(myTransform.position*1.01f, (punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position-myTransform.position).normalized*moveSpeed, Color.yellow);
			rigidbody.AddForce((punkte[(zaehler+1)%anzahlPunkte].GetComponent<Transform>().position-myTransform.position).normalized*moveSpeed*10);
		}

//		if (rigidbody.velocity >= maxSpeed)
//		{
//
//		}
	}

	IEnumerator turnTimer(float timer)
	{
		float time = Time.time;
		yield return new WaitForSeconds(timer*3.5f);
		//Debug.Log ("TimerAbgelaufen: "+(Time.time-time));
		//startTurning = false;
		turning = false;
		startWalking = true;
		StopCoroutine(turnTimer(1));
	}

	public void setPunkte(GameObject[] newPunkte)
	{
		punkte = newPunkte;
		anzahlPunkte = punkte.GetLength(0);
		myTransform.position = punkte[zaehler].GetComponent<Transform>().position;
		startTurning = true;
		turning = true;
	}
}
