using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public bool isFXEnabled;
	public bool isMusicEnabled;
	
	// Audio players components.
	public AudioSource EffectsSource;
	public AudioSource MusicSource;

	public AudioClip menuMusic;
	public AudioClip gameMusic;
	public AudioClip clickFX;
	public AudioClip correctFX;
	public AudioClip incorrectFX;
	public AudioClip winnerFX;
	public AudioClip lostFX;

	// Random pitch adjustment range.
	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;

	// Singleton instance.
	public static SoundManager Instance = null;

	// Initialize the singleton instance.
	/*
	private void Awake() {
		isFXEnabled = isMusicEnabled = true;
		MusicSource.loop = true;
		GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
		if (objs.Length > 1) {
			Destroy(this.gameObject);
		}
		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(this.gameObject);
	}
	*/
	
	// Play a single clip through the sound effects source.
	public void Play(AudioClip clip) {
		if (isFXEnabled) {
			EffectsSource.clip = clip;
			EffectsSource.Play();
		}
	}

	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip) {
		if (isMusicEnabled) {
			MusicSource.enabled = true;
			MusicSource.loop = true;
			MusicSource.clip = clip;
			MusicSource.Play();
		}
	}
	
	public void Play(int i) {
		if (isFXEnabled) {
			EffectsSource.enabled = true;
			if (i == 0) {
				EffectsSource.clip = clickFX;
			} else if (i == 1) {
				EffectsSource.clip = correctFX;
			} else if (i == 2) {
				EffectsSource.clip = incorrectFX;
			} else if (i == 3) {
				EffectsSource.clip = winnerFX;
			} else if (i == 4) {
				EffectsSource.clip = lostFX;
			}
			EffectsSource.Play();
		}
	}

	// Play a single clip through the music source.
	public void PlayMusic(int i) {
		if (isMusicEnabled) {
			MusicSource.enabled = true;
			MusicSource.loop = true;
			if (i == 0) { 
				MusicSource.clip = menuMusic;
			} else if (i == 1) {
				MusicSource.clip = gameMusic;
			}
			MusicSource.Play();
		}
	}

	public void playMenuMusic() {
		if (isMusicEnabled)
			PlayMusic(menuMusic);
	}

	public void playGameMusic() {
		if (isMusicEnabled)
			PlayMusic(gameMusic);
	}

	public void StopMusic() {
		MusicSource.Stop();
	}

	public void setMusicVolume(float f) {
		MusicSource.volume = f;
	}

	public void setFXVolume(float f) {
		EffectsSource.volume = f;
	}
}