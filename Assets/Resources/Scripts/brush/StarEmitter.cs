using UnityEngine;
using System.Collections;

public class StarEmitter : MonoBehaviour {
	
	public GameObject star;
	
	private ParticleEmitter emitter;
	private const float SPEED_DECAY = 0.9f;
	private const float MIN_SPEED = 0.001f;
	
	void Start () {
		emitter = GetComponent<ParticleEmitter> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Particle[] particles = emitter.particles;
		for (int i=0; i<particles.Length; ++i) {
			particles[i].velocity *= SPEED_DECAY;
			if ( Vector3.Magnitude(particles[i].velocity) <= MIN_SPEED ) {
				GameObject objParticle = (GameObject) Instantiate (star, particles[i].position, Quaternion.identity);
				objParticle.GetComponent<ParticleSystem>().startSize = particles[i].size;
				particles[i].energy = 0;
			}
		}
		emitter.particles = particles;
	}

	public void ActivateEmitter(bool emit){
		emitter.emit = emit;
	}
}
