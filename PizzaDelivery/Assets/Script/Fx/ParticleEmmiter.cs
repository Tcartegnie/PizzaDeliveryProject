using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmmiter : MonoBehaviour
{
	public SOBJfxList FXlist;
    public void InstanciateFX(string FXname, Vector3 position)
	{
		GameObject GO = Instantiate(FXlist.GetFXByName(FXname),position, new Quaternion());
		GO.GetComponent<ParticlePlayer>().CallPlayOneShoot();
	}
}
