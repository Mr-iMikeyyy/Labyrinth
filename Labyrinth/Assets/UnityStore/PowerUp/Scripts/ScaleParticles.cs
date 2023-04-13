using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScaleParticles : MonoBehaviour {
	void Update () {
		ParticleSystem.MainModule particles = GetComponent<ParticleSystem>().main;
		particles.startSize = transform.lossyScale.magnitude;
	}
}