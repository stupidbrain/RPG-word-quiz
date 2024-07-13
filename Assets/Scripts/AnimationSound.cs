using UnityEngine;
using System.Collections;

public class AnimationSound : StateMachineBehaviour {

	public AudioClip[] animationSounds;
	AudioSource AS;
	AudioClip mysound;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		AS = animator.GetComponent<AudioSource>();
	 	mysound = animationSounds[Random.Range(0,animationSounds.Length)];
		AS.PlayOneShot(mysound);

	}
}

