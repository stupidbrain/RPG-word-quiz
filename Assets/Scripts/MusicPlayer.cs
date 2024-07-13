using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class MusicPlayer : MonoBehaviour {

	private static MusicPlayer instance;
	public static MusicPlayer GetInstance() {
		return instance;
	}

	public static AudioSource music;

	void Awake () {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
			music = GetComponent<AudioSource>();
		}
		DontDestroyOnLoad(this.gameObject);
	}

	public static void MusicOn () {
		if (!music.isPlaying) 
			music.Play();
	}

	public static void MusicOff () {
		music.Stop();
	}

	public static void ChangeMusic (AudioClip newClip) {
		if (newClip != music.clip) {
		    music.clip = newClip;
			//if (!GameInfo.musicMute)
				music.Play();
		}
	}
}
