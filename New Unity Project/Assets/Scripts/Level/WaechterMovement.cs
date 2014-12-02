using UnityEngine;
using System.Collections;

public class WaechterMovement : MonoBehaviour {

	private bool walking;
	private Transform myTransform;
	public float moveSpeed;
	public float turnSpeed;
	private Vector3 moveDirection;
	private bool turning;
	private WaechterPoint currentPoint;


	// Use this for initialization
	void Start () {
		myTransform = transform;
		moveDirection = myTransform.forward;
		Debug.Log (""+moveDirection);
	}

	void FixedUpdate() {
		//Debug.DrawRay(myTransform.position*1f, myTransform.forward,Color.green);
		//Debug.DrawLine(myTransform.position*1.01f, (myTransform.position*1.01f+new Vector3(0.1f,0.3f,-0.9f)), Color.yellow);
		Debug.DrawRay(myTransform.position*1.01f, myTransform.forward*10,Color.magenta);
		if (!turning)
		{
			// aus: https://www.youtube.com/watch?v=gHeQ8Hr92P4)
			rigidbody.MovePosition(myTransform.position + transform.TransformDirection(moveDirection)*moveSpeed*Time.deltaTime);
		}
		else
		{
			Quaternion targetRotation = Quaternion.FromToRotation(myTransform.forward,currentPoint.returnDirection()) * myTransform.rotation;
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,targetRotation,turnSpeed * Time.deltaTime );

			//Debug.DrawRay(myTransform.position, myTransform.forward*10,Color.red, 0.1f);

			Ray ray;
			RaycastHit hit;
			//ray = new Ray(myTransform.position*1.005f, myTransform.forward); // direction of ray
			Physics.Raycast(myTransform.position*1.01f, myTransform.forward, out hit);


			Debug.Log ("hit.point"+hit.point);
			Debug.DrawLine(myTransform.position*1.01f, hit.point, Color.red);


			if (hit.collider == currentPoint.returnNextPoint().gameObject.collider)
			{
				StartCoroutine(timerTurning());
			}
		}
	}
	public void turn(WaechterPoint newCurrentPoint)
	{
		//Debug.Log ("turning");
		currentPoint = newCurrentPoint;
		//moveDirection = currentPoint.returnDirection();
		turning = true;
	}

	IEnumerator timerTurning()
	{
		yield return new WaitForSeconds(0.5f);
		turning = false;
	}

}
