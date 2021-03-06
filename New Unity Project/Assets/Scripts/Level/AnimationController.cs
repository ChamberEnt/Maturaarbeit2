﻿using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	//Setzt die Animationen auf die richtigen Ebenen und die richtige widerhohlungsart.
	void Start ()
	{
		animation.wrapMode = WrapMode.Loop;
		animation["jumpStart"].wrapMode = WrapMode.Once;
		animation["jumpStart"].layer = 1;
		animation["jumpEnd"].wrapMode = WrapMode.Once;
		animation["jumpEnd"].layer = 1;
		animation["Rollen2"].layer = 1;
	}

	//Startet die richtige Animation im richtigen Moment
	void Update ()
	{
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
			PlayerController.setDeltaGround(1.25f);
			if(PlayerController.returnWalking())
			{
				animation.Play ("Rollen2");
			}
			else if (animation.IsPlaying("Rollen2"))
			{
				animation.Stop();
				animation.CrossFade("idle1");
			}
		}
		else if(sphere.GetBlendShapeWeight(0) == 100)
		{
			GameObject.Find ("Player").GetComponent<PlayerController>().setVelocityToZero();
			sphere.SetBlendShapeWeight(0,0);
			GetComponentInParent<CapsuleCollider>().radius = 0.5f;
			PlayerController.setDeltaGround(1.1f);
			animation.Stop ("Rollen2");
		}
	}
}
