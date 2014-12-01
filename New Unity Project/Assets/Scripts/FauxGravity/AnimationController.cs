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
	}
	
	// Update is called once per frame
	void Update () {
		animation.CrossFade("idle1");
		SkinnedMeshRenderer sphere = GetComponentInChildren<SkinnedMeshRenderer>();

		if (PlayerControllerFauxGravity.returnWalking())
		{
			animation.Play("walk3");
		}
		if (PlayerControllerFauxGravity.returnJumping())
		{
			PlayerControllerFauxGravity.setJumping(false);
			animation.Play ("jumpStart");
		}
		if (PlayerControllerFauxGravity.returnRun())
		{

			sphere.SetBlendShapeWeight(1, 100);
			GetComponentInParent<CapsuleCollider>().radius = 0.65f;
			PlayerControllerFauxGravity.setDeltaGround(1.125f);
			if(PlayerControllerFauxGravity.returnWalking())
			{
				//animation.Play ("rollen");
			}
		}
		else if(sphere.GetBlendShapeWeight(1) == 100)
		{
			sphere.SetBlendShapeWeight(1,0);
			GetComponentInParent<CapsuleCollider>().radius = 0.5f;
			PlayerControllerFauxGravity.setDeltaGround(1.1f);
		}
	}
}
