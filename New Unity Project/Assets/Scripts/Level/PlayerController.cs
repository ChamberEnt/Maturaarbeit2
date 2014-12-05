using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public static float moveSpeed; //Bewegungsgeschwindigkeit
	private static float beginMoveSpeed;
	public static Vector3 moveDirection; //Laufrichtung (vom Spieler aus gesehen, ohne Drehung)
	private static Transform myTransform; //Position + Rotation + Grösse
	private static Vector3 beginMyScale;
	private static float deltaGround; //Gibt an wie weit der abstand zwischen Boden und Objekt sein kann ohne das das Objekt nicht am Boden steht, wichtig bei schrägen Flächen
	private static float beginDeltaGround;
	public static bool isGrounded; //ob das Objekt den Boden berührt
	private static bool jump; //ob leertaste gedrückt wird/gesprollgen wird
	public static float jumpPower; //stärke des sprollgs/höhe
	private static bool jumping; //ob gesprollgen wird, gebraucht um Spring animation zu starten
	//public static bool jumping2; //ob gesprollgen wird, gebraucht um Lande animation zu starten (not yet)
	private static bool walking; //ob gelaufen wird
	private static float groundLevel; //Auf welche höhe die Kamera eingestellt ist
	private static bool roll; //ob shift gedrückt wird/gerannt wird
	private static bool hasKey;
	
	void Start () {
		myTransform = transform;
		jump = false;
		jumping = false;
		walking = false;
		hasKey = false;

		beginMyScale = new Vector3(1,1,1);
		deltaGround = 1.1f;
		beginDeltaGround = 1.1f;
		moveSpeed = 1.5f;
		beginMoveSpeed = 1.5f;
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
		
		roll = Input.GetKey(KeyCode.LeftShift);
		
		
		//Debug.Log ("isGrounded: "+isGrounded);
		
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
		
		//Debug.Log (""+hit.distance);
		
		//*****************************************************************************************Walking
		//Debug.Log (myTransform.position + transform.TransformDirection(moveDirection));
		if (moveDirection == Vector3.zero && isGrounded)
		{
			setVelocityToZero();
		}
		else
		{
			// aus: https://www.youtube.com/watch?v=gHeQ8Hr92P4)
			if (roll)
			{
				myTransform.position += transform.TransformDirection(moveDirection)*moveSpeed*Time.deltaTime*7; //problem mit local moveDirection (drehen) anscheinend nicht mit local moveDirection sondern mit dem Attractor ein problem EDIT: wut?
			}
			else
			{
				//Debug.Log ("vorher "+(myTransform.position*100000));
				myTransform.position += transform.TransformDirection(moveDirection)*moveSpeed*Time.deltaTime;
				//Debug.Log ("nachher "+(myTransform.position*100000));
			}
		}
		
		if (jump)
		{
			if(roll)
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
	
	private void GameOver(int cause)
	{
		MenuGameOver.setCause(cause);
		Application.LoadLevel(3);
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
	public static bool returnRoll()
	{
		return roll;
	}
	//für Anpassung der Grösse des Charakters
	public static void multiplyAll(float multiplyer)
	{
		myTransform.localScale = beginMyScale;
		moveSpeed = beginMoveSpeed*multiplyer;
		deltaGround = beginDeltaGround*multiplyer;
		jumpPower = jumpPower*multiplyer;
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
	public static void setDeltaGround(float newDeltaGround)
	{
		deltaGround = newDeltaGround;
	}
	public static void setHasKey(bool newHasKey)
	{
		hasKey = newHasKey;
	}
	public static bool returnHasKey()
	{
		return hasKey;
	}
	public void setVelocityToZero()
	{
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
	}
}
