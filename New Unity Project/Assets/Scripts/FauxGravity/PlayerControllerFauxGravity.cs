using UnityEngine;
using System.Collections;

public class PlayerControllerFauxGravity : MonoBehaviour {

	public static float moveSpeed; //Bewegungsgeschwindigkeit
	public static Vector3 moveDirection; //Laufrichtung (vom Spieler aus gesehen, ohne Drehung)
	private static Transform myTransform; //Position + Rotation + Grösse
	private static float deltaGround; //Gibt an wie weit der abstand zwischen Boden und Objekt sein kann ohne das das Objekt nicht am Boden steht, wichtig bei schrägen Flächen
	public static bool isGrounded; //ob das Objekt den Boden berührt
	private bool jump; //ob leertaste gedrückt wird/gesprungen wird
	public static float jumpPower; //stärke des sprungs/höhe
	private static bool jumping; //ob gesprungen wird, gebraucht um Spring animation zu starten
	//public static bool jumping2; //ob gesprungen wird, gebraucht um Lande animation zu starten (not yet)
	private static bool walking; //ob gelaufen wird
	private static float groundLevel; //Auf welche höhe die Kamera eingestellt ist
	private static bool run; //ob shift gedrückt wird/gerannt wird

	void Start () {
		myTransform = transform;
		jump = false;
		jumping = false;
		walking = false;

		deltaGround = 1.1f;
		moveSpeed = 1.5f;
		jumpPower = 200;
	}


	void Update() {
		//**************************************************************************************** moveDirection update (input):

		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;
		if (moveDirection == Vector3.zero)
		{
			walking = false;
		}
		else 
		{
			walking = true;
		}

		run = Input.GetKey(KeyCode.LeftShift);


		//Debug.Log ("groundlevelCamera: "+groundLevelCamera);

		//********************************************************************************************* Jump update (input):

		
		if (Input.GetButtonDown("Jump"))
		{
			if (isGrounded)
			{
				jump = true;
				//groundLevel = myTransform.position;
			}
		}

	}

	void FixedUpdate() {
		//**************************************************************************************** isGrounded update: (teils aus: http://answers.unity3d.com/questions/155907/basic-movement-walking-on-walls.html)
		Ray ray;
		RaycastHit hit;
		ray = new Ray(myTransform.position, -myTransform.position); // direction of ray
		Physics.Raycast(ray, out hit); // cast ray downwards
		
		//Debug.Log ("hit.distance "+hit.distance);
		Debug.DrawLine (transform.position, hit.point, Color.cyan);
		
		if (hit.distance <= deltaGround)
		{
			isGrounded = true;
			groundLevel = myTransform.position.magnitude;
		}
		else
		{
			isGrounded = false;
		}

		//*****************************************************************************************Walking
		if (moveDirection == Vector3.zero && isGrounded)
		{
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
		else
		{
			// aus: https://www.youtube.com/watch?v=gHeQ8Hr92P4)
			if (run)
			{
				rigidbody.MovePosition(myTransform.position + transform.TransformDirection(moveDirection)*moveSpeed*Time.deltaTime*7); //problem mit local moveDirection (drehen) anscheinend nicht mit local moveDirection sondern mit dem Attractor ein problem EDIT: wut?
			}
			else
			{
				rigidbody.MovePosition(myTransform.position + transform.TransformDirection(moveDirection)*moveSpeed*Time.deltaTime);
			}
		}

		if (jump)
		{
			if(run)
			{
				//Debug.Log ("BigJump");
				rigidbody.AddForce(myTransform.position.normalized * jumpPower * 5);
			}
			else
			{
				rigidbody.AddForce(myTransform.position.normalized * jumpPower);
			}
			jumping = true;
			jump = false;
		}
	}


	void GameOver(int cause)
	{
		MenuGameOver.setCause(cause);
		Application.LoadLevel(2);
	}
	
	public static Vector3 returnMoveDirection()
	{
		return moveDirection;
	}
	public static bool returnJumping()
	{
		return jumping;
	}
	public static void setJumping (bool jumping_)
	{
		jumping = jumping_;
	}
	public static bool returnRun()
	{
		return run;
	}
	//für Anpassung der Grösse des Charakters
	public static void multiplyAll(float multiplyer)
	{
		myTransform.localScale = new Vector3(multiplyer, multiplyer, multiplyer);
		moveSpeed = moveSpeed*multiplyer;
		deltaGround = deltaGround*multiplyer;
		//jumpPower?
	}
	public static float returnGroundLevel()
	{
		return groundLevel;
	}
	public static Vector3 returnMyPosition()
	{
		return myTransform.position;
	}
	public static bool returnWalking()
	{
		return walking;
	}
	public static void setDeltaGround(float x)
	{
		deltaGround = x;
	}
}
