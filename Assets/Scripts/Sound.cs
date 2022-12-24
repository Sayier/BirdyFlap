using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [SerializeField]
    public AudioClip clip;
    [SerializeField]
    public string soundName;

    [SerializeField]
    [Range(0f,1f)]
    public float soundVolume;
    [SerializeField]
    [Range(0.1f,3f)]
    public float soundPitch;

    [HideInInspector]
    public AudioSource source;
}
