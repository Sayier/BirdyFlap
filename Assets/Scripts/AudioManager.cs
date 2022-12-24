using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] gameSounds;

    void Awake()
    {
        foreach (Sound sound in gameSounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.soundVolume;
            sound.source.pitch = sound.soundPitch;
        }
    }

    public void Play(string soundName)
    {
        Sound sound = Array.Find<Sound>(gameSounds,sound => sound.soundName == soundName);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        sound.source.Play();
    }
}
