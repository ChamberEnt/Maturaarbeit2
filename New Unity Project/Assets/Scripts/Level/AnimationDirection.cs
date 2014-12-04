using UnityEngine;
using System.Collections;

public class AnimationDirection : MonoBehaviour {

	private float degreesToRotate = 0; //Gibt an wo hin gedreht werden muss, immer vom Spieler aus aber ohne dessen eigene Drehung (um die eigene Achse) zu berücksichtigen
	public float turnSpeed; //Drehgeschwindigkeit
	private Vector3 myPos; //nur Position aus myTransform

	void Update ()
	{
		if (PlayerController.moveDirection != Vector3.zero)
		{
			Quaternion targetRotation = transform.localRotation;
			if (Input.GetAxisRaw("Horizontal") == 1)
			{
				//Debug.Log("Right");
				degreesToRotate = 270;
				targetRotation = new Quaternion(0, -0.7f, 0, -0.7f);
			}
			else if (Input.GetAxisRaw("Horizontal") == -1)
			{
				//Debug.Log("Left");
				degreesToRotate = 90;
				targetRotation = new Quaternion(0, -0.7f, 0, 0.7f);
			}

			if (Input.GetAxisRaw("Vertical") == 1)
			{
				if (degreesToRotate == 0)
				{
					//Debug.Log("Up");
					degreesToRotate = 360;
					targetRotation = new Quaternion(0, 0, 0, -1f);
				}
				else if (degreesToRotate == 90)
				{
					//Debug.Log("Up + Left");
					degreesToRotate = 45;
					targetRotation = new Quaternion(0, -0.4f, 0, 0.9f);
				}
				else if (degreesToRotate == 270)
				{
					//Debug.Log("Up + Right");
					degreesToRotate = 315;
					targetRotation = new Quaternion(0, -0.4f, 0, -0.9f);
				}
			}
			else if (Input.GetAxisRaw("Vertical") == -1)
			{
				if (degreesToRotate == 0)
				{
					//Debug.Log("Down");
					degreesToRotate = 180;
					targetRotation = new Quaternion(0, -1f, 0, 0);
				}
				else if (degreesToRotate == 90)
				{
					//Debug.Log("Down + Left");
					degreesToRotate = 135;
					targetRotation = new Quaternion(0, -0.9f, 0, 0.4f);
				}
				else if (degreesToRotate == 270)
				{
					//Debug.Log("Down + Right");
					degreesToRotate = 225;
					targetRotation = new Quaternion(0, -0.9f, 0, -0.4f);
				}
			}
			if (targetRotation != transform.localRotation)
			{
				if (PlayerController.returnRoll())
				{
					transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, turnSpeed * Time.deltaTime * 3);
				}
				else
				{
					transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, turnSpeed * Time.deltaTime );
				}
			}
			degreesToRotate = 0;
		}
	}
}
