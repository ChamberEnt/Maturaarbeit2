using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	//private AnimationState idle;
	//private AnimationState walk;

	void Start () {
		//idle = animation["idle1"];
		//walk = animation["walk3"];

		animation.wrapMode = WrapMode.Loop;

		//setup für jump, wrapMode nur Once und layer 1 damit es walk3 und idle1 nicht unterbricht
		animation["jumpStart"].wrapMode = WrapMode.Once;
		animation["jumpStart"].layer = 1;
		animation["jumpEnd"].wrapMode = WrapMode.Once;
		animation["jumpEnd"].layer = 1;
		//animation["RollenStart"].layer = 1;
		//animation["RollenStart"].wrapMode = WrapMode.Once;
		//animation["RollenEnd"].wrapMode = WrapMode.Once;

	}
	
	// Update is called once per frame
	void Update () {
		float multyplier = CharacterScaler.returnMultiplyer();
		animation.CrossFade("idle1");
		SkinnedMeshRenderer sphere = GetComponentInChildren<SkinnedMeshRenderer>();

		if (PlayerController.returnWalking())
		{
			animation.Play("walk3");
		}
		if (PlayerController.returnJumping())
		{
			PlayerController.setJumping(false);
			animation.Play ("jumpStart");
		}
		if (PlayerController.returnRoll())
		{

			sphere.SetBlendShapeWeight(0, 100);
			GetComponentInParent<CapsuleCollider>().radius = 0.65f;
			PlayerController.setDeltaGround(1.125f);
			if(PlayerController.returnWalking())
			{
				//animation.Play ("Rollen");
			}
		}
		else if(sphere.GetBlendShapeWeight(0) == 100)
		{
			sphere.SetBlendShapeWeight(0,0);
			GetComponentInParent<CapsuleCollider>().radius = 0.5f;
			PlayerController.setDeltaGround(1.1f);
		}
	}
}
