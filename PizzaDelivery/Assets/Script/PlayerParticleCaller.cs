using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleCaller : MonoBehaviour
{
   public ParticleEmmiter particleEmmiter;
   public Transform FxWalkTransform;
   public Transform FxHitTransform;
	
	public void SetParticleEmmiter(ParticleEmmiter emmiter)
	{
		particleEmmiter = emmiter;
	}
	public void CallHitParticle()
	{
		particleEmmiter.InstanciateFX("Hit", FxHitTransform.position);
	}
	public void CallWalkParticle()
	{
		particleEmmiter.InstanciateFX("Smoke", FxWalkTransform.position);
	}
}
