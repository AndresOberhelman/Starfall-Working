using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;
	public Sound[] musicSounds,sfxSounds,runSounds;
	public AudioSource musicSource,sfxSource,runSource;
	private string currentSceneName;
	

	private void Awake(){
		if (Instance == null){
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else {
			Destroy(gameObject);
		}
		
	}

	void OnEnable() {
    SceneManager.sceneLoaded += SceneLoaded;
}
public void PlaySFX(string name){
	Sound s = Array.Find(sfxSounds, x=> x.name == name);
	if (s ==null){
		Debug.Log("Sound Not Found");
	}
	else{
		sfxSource.PlayOneShot(s.clip);
	}
}

void OnDisable() {
    SceneManager.sceneLoaded -= SceneLoaded;
}
void Start() {
    SceneManager.sceneLoaded += SceneLoaded;
}
void SceneLoaded(Scene scene, LoadSceneMode mode) {
	Debug.Log("Scene loaded: " + scene.name);
	if (!string.IsNullOrEmpty(currentSceneName))
        {
            StopMusic();
        }

    currentSceneName = scene.name;
    switch (scene.name) {
        case "Main Menu":
            PlayMusic("Theme");
            break;
        case "Level1.1":
            PlayMusic("Level1");
            break;
        // add more cases for each scene in game
        default:
            StopMusic();
            break;
    }

	float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
    MusicVolume(savedMusicVolume);
}

void StopMusic() {
    // Assuming the audio source component is attached to the same game object as this script
    
    if (musicSource != null) {
        musicSource.Stop();
    }
}
	public void PlayMusic(string name)
	{
		Sound s = Array.Find(musicSounds, x => x.name == name);

		if (s == null)
		{
			Debug.Log("Sound Not Found");

		}

		else {
			musicSource.clip = s.clip;
			musicSource.Play();
		}
	}

	public void ToggleMusic(){
		musicSource.mute =!musicSource.mute;

	}
	public void MusicVolume(float volume){
		musicSource.volume = volume;
		PlayerPrefs.SetFloat("MusicVolume", volume);
	}

	public void ToggleSFX(){
		sfxSource.mute =!sfxSource.mute;
	}

	public void SFXVolume(float volume){
		sfxSource.volume = volume;
	}

	public void PlayRun(string name){
	Sound s = Array.Find(runSounds, x=> x.name == name);
	if (s ==null){
		Debug.Log("Sound Not Found");
	}
	else{
		runSource.PlayOneShot(s.clip);
	}
}
	
}
