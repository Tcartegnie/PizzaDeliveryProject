using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
  
    public ParticleSystem particle;
	// Start is called before the first frame update

	public void CallParticlePlay()
	{
        StartCoroutine(PlayParticle());
	}

	public void CallPlayOneShoot()
	{
		StartCoroutine(PlayOneShoot());
	}

    public IEnumerator PlayParticle()
	{
        particle.Play();
        yield return new WaitForSeconds(particle.main.duration);
        particle.Stop();
    }

	public IEnumerator PlayOneShoot()
	{
		particle.Play();
		yield return new WaitForSeconds(particle.main.duration);
		Destroy(gameObject);
	}

}
